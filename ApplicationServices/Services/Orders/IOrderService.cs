using ApplicationServices.Services.Orders.Requests;
using ApplicationServices.Services.Orders.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.Orders
{
    public interface IOrderService
    {
        Task<ICollection<OrderResponse>> GetAllOrders();
        Task<OrderResponse> GetOrderById(long? id);
        Task AddOrder(OrderRequest request);
        Task UpdateOrder(long orderId, OrderUpdateRequest request);
        Task<bool> DeleteOrder(long? id);
    }
}
