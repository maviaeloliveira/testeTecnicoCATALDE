using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IOcorrenciaRepository: IRepository<Ocorrencia>
    {
        public Task<List<Ocorrencia>> GetOcorrenciasPorIdPedido(int idPedido);
    }
}
