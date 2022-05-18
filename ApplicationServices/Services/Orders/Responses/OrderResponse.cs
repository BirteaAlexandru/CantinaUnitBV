using Domain;
using Domain.Users;

namespace ApplicationServices.Services.Orders.Responses
{
    public class OrderResponse
    {   
        public long Id { get; set; }
        public User User { get; set; }
        public ICollection<RecipesOrder> RecipesOrder { get; set; }

    }
}

