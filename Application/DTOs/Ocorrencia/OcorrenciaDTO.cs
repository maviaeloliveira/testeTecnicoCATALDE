using Application.DTOs.Pedido;
using Application.DTOs.TipoOcorrencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Ocorrencia
{
    public class OcorrenciaDTO
    {
        public int IdOcorrencia { get; set; }
        public DateTime HoraOcorrencia { get; set; }
        public int IdTipoOcorrencia { get; set; }
        public TipoOcorrenciaDTO TipoOcorrencia { get; set; }
        public int IdPedido { get; set; }
        public PedidoDTO Pedido { get; set; }
    }
}
