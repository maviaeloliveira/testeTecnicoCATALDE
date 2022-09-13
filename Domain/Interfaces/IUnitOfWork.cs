using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IPedidoRepository pedidoRepository { get; }
        IOcorrenciaRepository ocorrenciaRepository { get; }
        ITipoOcorrenciaRepository tipoOcorrenciaRepository { get; }

        void Commit();
    }
}
