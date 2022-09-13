using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OcorrenciaRepository : Repository<Ocorrencia>, IOcorrenciaRepository
    {
        public OcorrenciaRepository(ApplicationDbContext contexto) : base(contexto)
        {
        }

        public async Task<List<Ocorrencia>> GetOcorrenciasPorIdPedido(int idPedido)
        {
            return await _context.Ocorrencias
                .Where(a => a.IdPedido.Equals(idPedido))
                .Include(a=> a.Pedido)
                .Include(a => a.TipoOcorrencia)
                .OrderByDescending(a=> a.HoraOcorrencia)
                .ToListAsync();
        }

    }
}
