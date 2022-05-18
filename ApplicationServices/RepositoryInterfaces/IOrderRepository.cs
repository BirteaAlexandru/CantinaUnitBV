using Domain;

namespace ApplicationServices.RepositoryInterfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<ICollection<Order>> GetOrderAsync();
        Task<Order> GetOrderByIdAsync(long? id, bool isTracked = false);
    }
}
