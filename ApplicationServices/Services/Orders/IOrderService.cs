using ApplicationServices.Base;
using ApplicationServices.Services.Orders.Requests;
using ApplicationServices.Services.Orders.Responses;
using Domain.Base;
using Domain.Search;

namespace ApplicationServices.Services.Orders
{
    public interface IOrderService
    {
        Task<PartialCollectionResponse<OrderResponse>> GetAllOrders(SearchArgs searchArgs);
        Task<Result<OrderResponse>> GetOrderById(long? id);
        Task<Result> AddOrder(OrderRequest request);
        Task<Result> UpdateOrder(long orderId, OrderUpdateRequest request);
        Task<Result> DeleteOrder(long? id);
    }
}
