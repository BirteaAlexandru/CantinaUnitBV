using Domain.Base;

namespace Domain
{
    public class RecipesOrder: Entity
    {
        public long RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
