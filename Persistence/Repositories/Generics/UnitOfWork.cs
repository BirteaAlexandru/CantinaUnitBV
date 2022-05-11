using ApplicationServices.RepositoryInterfaces.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;

namespace Persistence.Repositories.Generics
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CantinaBvContext _context; 
        public UnitOfWork(CantinaBvContext context)
        {
            _context = context;
        }

        public async Task<IScopedUnitOfWork> CreateScopeAsync()
        {
            var currentTransaction = _context.Database.CurrentTransaction;
            IDbContextTransaction transaction;

            if (currentTransaction != null)
            {
                transaction = await _context.Database.UseTransactionAsync(currentTransaction.GetDbTransaction());
            }
            else
            {
                transaction = await _context.Database.BeginTransactionAsync();
            }

            return new ScopedUnitOfWork(_context, transaction);
        }
    }
}
