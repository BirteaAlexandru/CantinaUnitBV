#nullable disable
using ApplicationServices.Services.Orders;
using ApplicationServices.Services.Orders.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CantinaUnitBV.Pages.Orders
{
    public class DetailsModel : PageModel
    {
        public DetailsModel(IOrderService orderService)
        {
            OrderService = orderService;
        }

        [BindProperty]
        public OrderResponse OrderDto { get; set; }
        private IOrderService OrderService { get; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            OrderDto = await OrderService.GetOrderById(id);

            if (OrderDto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
