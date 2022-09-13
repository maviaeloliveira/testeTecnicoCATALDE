using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext contexto) : base(contexto)
        {
        }

        public async Task<Pedido> GetPedidoPorNumeroPedido(int numero)
        {
            return await _context.Pedidos
                .Where(a => a.NumeroPedido.Equals(numero))
                .FirstOrDefaultAsync();
        }


    }
}
