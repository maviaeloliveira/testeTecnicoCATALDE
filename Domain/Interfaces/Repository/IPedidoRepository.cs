using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repository
{
    public interface IPedidoRepository: IRepository<Pedido>
    {
        Task<Pedido> GetPedidoPorNumeroPedido(int numero);
    }
}
