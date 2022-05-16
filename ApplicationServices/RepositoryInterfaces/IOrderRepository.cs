using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.RepositoryInterfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<ICollection<Order>> GetOrderAsync();
        Task<Order> GetOrderByIdAsync(long? id, bool isTracked = false);
    }
}
