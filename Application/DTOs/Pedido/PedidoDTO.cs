using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Pedido
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public int NumeroPedido { get; set; }
        public DateTime HoraPedido { get; set; }
        public bool IndCancelado { get; set; }
        public bool IndConcluido { get; set; }
    }
}
