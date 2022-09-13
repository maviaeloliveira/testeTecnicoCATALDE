using Application.Application.Exceptions;
using AutoMapper;
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
    public class PedidoService : IPedidoService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PedidoService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        

        public async Task<Pedido> GetById(int? id)
        {
            var pedido = await _unitOfWork.pedidoRepository.GetById(id);
            return pedido;
        }        

        public async Task Add(Pedido pedido)
        {
            if(pedido.NumeroPedido == 0)
                throw new BusinessException("Número do pedido obrigatório");

            var pedidoExistente = await _unitOfWork.pedidoRepository.GetPedidoPorNumeroPedido(pedido.NumeroPedido);

            if (pedidoExistente != null)
                throw new BusinessException("Número de pedido já existe na base de dados");
            else
            {
                pedido.HoraPedido = DateTime.Now;

                pedido = await _unitOfWork.pedidoRepository.Add(pedido);

                _unitOfWork.Commit();
            }
        }
        
        
        public Task Remove(int? id)
        {
            throw new NotImplementedException();
        }

    }
}
