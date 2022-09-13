using Application.Application.Exceptions;
using AutoMapper;
using Domain.Common.Enum;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OcorrenciaService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }       

        public async Task<Ocorrencia> GetById(int? id)
        {
            var ocorrencia = await _unitOfWork.ocorrenciaRepository.GetById(id);
            return ocorrencia;
        }

        public async Task Add(Ocorrencia ocorrencia)
        {
            try
            {
                if (ocorrencia.IdPedido == 0)
                    throw new BusinessException("Número do pedido obrigatório");
                if (ocorrencia.IdTipoOcorrencia == 0)
                    throw new BusinessException("Tipo de ocorrencia obrigatório");

                var pedidoExistente = await _unitOfWork.pedidoRepository.GetById(ocorrencia.IdPedido);

                if (pedidoExistente == null)
                    throw new BusinessException("Número de pedido não existe na base de dados");

                if (pedidoExistente.Finalizado)
                    throw new BusinessException("O pedido já foi finalizado anteriormente.");




                ocorrencia.HoraOcorrencia = DateTime.Now;

                var ocorrenciasExistentes = await _unitOfWork.ocorrenciaRepository.GetOcorrenciasPorIdPedido(ocorrencia.IdPedido);

                var ocorrenciasUltimos10Min = ocorrenciasExistentes.Where(a => a.HoraOcorrencia.AddMinutes(10) >= DateTime.Now).ToList();

                if (ocorrenciasUltimos10Min.Any(a => a.IdTipoOcorrencia == ocorrencia.IdTipoOcorrencia))
                    throw new BusinessException("O tempo de cadastro deve ser maior que 10 minutos");

                //Removido a ocorrencia do tipo Em rota, pois não faz sentido finalizar um pedido se ele tiver uma segunda ocorrencia desse tipo.
                if (ocorrenciasExistentes.Where(a => a.IdTipoOcorrencia != EnumTipoOcorrencia.EM_ROTA_DE_ENTREGA.GetHashCode()).ToList().Any(b => b.IdTipoOcorrencia == ocorrencia.IdTipoOcorrencia))
                    ocorrencia.EhFinalizadora = true;

                await _unitOfWork.ocorrenciaRepository.Add(ocorrencia);

                if (ocorrencia.EhFinalizadora
                    || ocorrencia.IdTipoOcorrencia == EnumTipoOcorrencia.ENTEGRA_SUCESSO.GetHashCode())
                {
                    var pedido = await _unitOfWork.pedidoRepository.GetById(ocorrencia.IdPedido);

                    if (ocorrencia.IdTipoOcorrencia == EnumTipoOcorrencia.ENTEGRA_SUCESSO.GetHashCode())
                        pedido.EhConcluido = true;
                    else
                        pedido.EhCancelado = true;

                    await _unitOfWork.pedidoRepository.Update(pedido);
                }
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task Remove(int? id)
        {
            var ocorrencia = await _unitOfWork.ocorrenciaRepository.GetById(id);

            if (ocorrencia == null)
                throw new BusinessException("Ocorrencia inexistente");

            var pedido = await _unitOfWork.pedidoRepository.GetById(ocorrencia.IdPedido);

            if(pedido.Finalizado)
                throw new BusinessException("Exclusão não realizada. Pedido já se encontra finalizado.");

            await _unitOfWork.ocorrenciaRepository.Delete(ocorrencia);

            _unitOfWork.Commit();
        }
                
    }
}
