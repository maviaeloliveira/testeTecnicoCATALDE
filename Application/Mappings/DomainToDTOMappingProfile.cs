using Application.DTOs.Ocorrencia;
using Application.DTOs.Pedido;
using Application.DTOs.TipoOcorrencia;
using AutoMapper;
using Domain.Entities;

namespace Application.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
            CreateMap<Pedido, PedidoInsertDTO>().ReverseMap();
            CreateMap<Ocorrencia, OcorrenciaDTO>().ReverseMap();
            CreateMap<Ocorrencia, OcorrenciaInsertDTO>().ReverseMap();
            CreateMap<TipoOcorrencia, TipoOcorrenciaDTO>().ReverseMap();
        }
    }
}
