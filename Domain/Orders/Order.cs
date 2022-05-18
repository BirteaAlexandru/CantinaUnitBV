using Domain.Base;
using Domain.Users;

namespace Domain
{
    public class Order: Entity
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<RecipesOrder> RecipesOrders { get; set; }

        private Order()
        {
        }

        private Order(long userId)
        {
            UserId= userId;
        }

        public static Result<Order> Create(long userId)
        {
            if (userId == 0)
            {
                return Result.Failure<Order>("Order id is mandatory");
            }

            var order = new Order(userId);

            return Result.Success(order);
        }

        public Result<Order> Update(User user, ICollection<RecipesOrder> recipesOrders)
        {
            if (user == null)
            {
                return Result.Failure<Order>("User is mandatory");
            }
            if (!recipesOrders.Any())
            {
                return Result.Failure<Order>("Orders are mandatory");
            }
            
            User= user;
            RecipesOrders= recipesOrders;

            return Result.Success(this);
        }
    }
}
