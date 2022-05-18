using Domain.Base;

namespace Domain
{
    public class RecipesOrder: Entity
    {
        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }

        public RecipesOrder()
        {

        }

        public RecipesOrder(long recipeId, long orderId)
        {
            RecipeId = recipeId;
            OrderId = orderId;
        }

        public static Result<RecipesOrder> Create(long recipeId, long orderId)
        {
          
            if (recipeId == 0)
            {
                return Result.Failure<RecipesOrder>("Recipe is mandatory");
            }
            if (orderId == 0)
            {
                return Result.Failure<RecipesOrder>("Order is mandatory");
            }

            var user = new RecipesOrder(recipeId, orderId);

            return Result.Success(user);
        }
    }
}
