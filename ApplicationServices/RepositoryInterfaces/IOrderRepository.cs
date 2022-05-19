using ApplicationServices.Base;
using ApplicationServices.RepositoryInterfaces.Generics;
using Domain;
using Domain.Search;

namespace ApplicationServices.RepositoryInterfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IPartialCollection<Order>> GetOrderAsync(SearchArgs searchArgs);
        Task<Order> GetOrderByIdAsync(long? id, bool isTracked = false);
    }
}
