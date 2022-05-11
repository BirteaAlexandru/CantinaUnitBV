using ApplicationServices.RepositoryInterfaces.Generics;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;

namespace Persistence.Repositories.Generics
{
    public class ScopedUnitOfWork: IScopedUnitOfWork
    {
        private readonly CantinaBvContext _context;
        private readonly IDbContextTransaction _transaction;
        public ScopedUnitOfWork(CantinaBvContext context, IDbContextTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        public Task SaveAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                await _transaction.RollbackAsync(cancellationToken);
            }
            finally{
                _transaction?.Dispose();
            }
        }
    }
}
