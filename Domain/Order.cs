using Domain.Base;
using Domain.Users;

namespace Domain
{
    public class Order: Entity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<RecipesOrder> RecipesOrders { get; set; }
    }
}
