using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Ocorrencia
    {
        public int IdOcorrencia { get; set; }        
        public int IdTipoOcorrencia { get; set; }
        public TipoOcorrencia TipoOcorrencia { get; set; }
        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }
        public DateTime HoraOcorrencia { get; set; }
        public bool EhFinalizadora { get; set; }
    }
}
