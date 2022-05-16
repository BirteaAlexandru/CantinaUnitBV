#nullable disable
using ApplicationServices.Services.Orders.Responses;
using ApplicationServices.Services.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CantinaUnitBV.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(IOrderService orderService,
                           ILogger<DeleteModel> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
        private readonly IOrderService _orderService;

        [BindProperty]
        public OrderResponse Order { get; set; }
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(long? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _orderService.GetOrderById(id);
            if (Order == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            await _orderService.DeleteOrder(id);
            return RedirectToPage("./Index");
           
        }
    }
}
