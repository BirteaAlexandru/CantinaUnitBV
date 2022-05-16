#nullable disable
using Microsoft.AspNetCore.Mvc;
using CantinaUnitBV.Pages.Users;
using ApplicationServices.Services.Orders;
using ApplicationServices.Services.Orders.Responses;
using ApplicationServices.Services.Orders.Requests;

namespace CantinaUnitBV.Pages.Orders
{
    public class EditModel : RolePakageModel
    {

        public EditModel(IOrderService orderService)
        {
            OrderService = orderService;
        }

        public OrderResponse OrderResponse { get; set; }
        [BindProperty]
        public OrderRequest OrderRequest { get; set; }
        private IOrderService OrderService { get; }
        
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderResponse = await OrderService.GetOrderById(id);

            if (OrderResponse == null)
            {
                return NotFound();
            }

            OrderRequest = new OrderRequest
            {
                UserId= OrderResponse.User.Id,
            };  

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(long id)
        {
            var emptyUser = new OrderUpdateRequest();
            
            if (await TryUpdateModelAsync<OrderUpdateRequest>(
                emptyUser,
                "OrderUpdateRequest",   // Prefix for form value.
                 s => s.User, s => s.RecipesOrder))
            {
                await OrderService.UpdateOrder(id, emptyUser);
                return RedirectToPage("./Index");
            }
            return Page();
        }

        //private bool UserExists(long id)
        //{
        //    return _context.Users.Any(e => e.Id == id);

        //}
    }
}
