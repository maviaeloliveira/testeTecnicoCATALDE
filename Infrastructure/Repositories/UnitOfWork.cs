using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private PedidoRepository _pedidoRepository;
        private OcorrenciaRepository _ocorrenciaRepository;
        private TipoOcorrenciaRepository _tipoOcorrenciaRepository;
        
        public ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public IPedidoRepository pedidoRepository
        {
            get
            {
                return _pedidoRepository = _pedidoRepository ?? new PedidoRepository(_context);
            }
        }

        public IOcorrenciaRepository ocorrenciaRepository
        {
            get
            {
                return _ocorrenciaRepository = _ocorrenciaRepository ?? new OcorrenciaRepository(_context);
            }
        }

        public ITipoOcorrenciaRepository tipoOcorrenciaRepository
        {
            get
            {
                return _tipoOcorrenciaRepository = _tipoOcorrenciaRepository ?? new TipoOcorrenciaRepository(_context);
            }
        }



        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
