#nullable disable
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationServices.Services.Orders;
using ApplicationServices.Services.Orders.Responses;

namespace CantinaUnitBV.Pages.Orders
{
    public class IndexModel : PageModel
    {

        public IndexModel(IOrderService orderService)
        {
            OrderService = orderService;
        }
        public IList<OrderResponse> Orders { get;set; }
        private IOrderService OrderService { get; }

        public async Task OnGetAsync()
        {
           // var orders = await OrderService.GetAllOrders();

          //  Orders = orders.ToList();
        }
    }
}
