using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.RepositoryInterfaces.Generics
{
    public interface IScopedUnitOfWork
    {
        Task SaveAsync(CancellationToken cancellationToken = default); 
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
