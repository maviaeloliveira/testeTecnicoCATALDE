using Application.DTOs.Pedido;
using Application.DTOs.TipoOcorrencia;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Ocorrencia
{
    public class OcorrenciaInsertDTO
    {
        public int IdTipoOcorrencia { get; set; }
        public int IdPedido { get; set; }
    }
}
