 #nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Services.Orders;
using ApplicationServices.Services.Orders.Requests;
using ApplicationServices.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CantinaUnitBV.Pages.Orders
{
    public class CreateModel : PageModel
    {
        public CreateModel(IOrderService orederService)
        {
            _orderService = orederService;
        }
        private readonly IOrderService _orderService;
        
        public async Task<IActionResult> OnGet()
        {
            


            return Page();
        }

        [BindProperty]
        public OrderRequest OrderRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyOerder = new OrderRequest();

            if (await TryUpdateModelAsync<OrderRequest>(
                emptyOerder,
                "OrderRequest",   // Prefix for form value.
                s => s.UserId))
            {
                await _orderService.AddOrder(emptyOerder);
                return RedirectToPage("./Index");
            }
            
              return Page();


          
        }
        
    }
}
