using Domain;
using Domain.Users;

namespace ApplicationServices.Services.Orders.Responses
{
    public class OrderUpdateRequest
    {
        public User User { get; set; }
        public ICollection<RecipesOrder> RecipesOrder { get; set; }
    }
}
