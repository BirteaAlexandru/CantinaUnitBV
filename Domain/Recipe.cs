using Domain.Base;

namespace Domain
{
    public class Recipe: Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Ingredients { get; set; }
        public bool Available { get; set; }
        public int Quantity { get; set; }
        public ICollection<RecipesOrder> RecipesOrders { get; set; }
    }
}
