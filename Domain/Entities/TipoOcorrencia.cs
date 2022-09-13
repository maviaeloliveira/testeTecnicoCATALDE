using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TipoOcorrencia
    {
        public int IdTipoOcorrencia { get; set; }
        public string Descricao { get; set; }
        public ICollection<Ocorrencia>? Ocorrencias { get; set; }
    }
}
