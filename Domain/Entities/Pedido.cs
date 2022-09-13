using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int NumeroPedido { get; set; }
        public DateTime HoraPedido{ get; set; }
        public bool EhCancelado { get; set; }
        public bool EhConcluido { get; set; }
        public ICollection<Ocorrencia>? Ocorrencias { get; set; }

        public bool Finalizado
        {
            get
            {
                return (EhCancelado || EhConcluido);
            } 
        }
    }
}
