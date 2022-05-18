using ApplicationServices.Services.Orders.Requests;
using ApplicationServices.Services.Orders.Responses;
using Domain.Base;

namespace ApplicationServices.Services.Orders
{
    public interface IOrderService
    {
        Task<ICollection<OrderResponse>> GetAllOrders();
        Task<Result<OrderResponse>> GetOrderById(long? id);
        Task<Result> AddOrder(OrderRequest request);
        Task<Result> UpdateOrder(long orderId, OrderUpdateRequest request);
        Task<Result> DeleteOrder(long? id);
    }
}
