using Domain.Entities;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class TipoOcorrenciaRepository : Repository<TipoOcorrencia>, ITipoOcorrenciaRepository
    {
        public TipoOcorrenciaRepository(ApplicationDbContext contexto) : base(contexto)
        {
        }
    }
}
