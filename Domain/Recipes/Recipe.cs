using Domain.Base;

namespace Domain
{
    public class Recipe: Entity
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public string Ingredients { get; private set; }
        public bool Available { get; private set; }
        public int Quantity { get; private set; }
        public ICollection<RecipesOrder> RecipesOrders { get; set; }

        private Recipe()
        {
        }

        private Recipe(string name, int price, string ingredients, bool available, int quantity)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
            Available = available;
            Quantity = quantity;
        }

        public static Result<Recipe> Create(string name, int price, string ingredients, bool available, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Recipe>("Name cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(ingredients))
            {
                return Result.Failure<Recipe>("Ingredients cannot be empty");
            }

            if (price == 0)
            {
                return Result.Failure<Recipe>("Price is mandatory");
            }
            if (quantity == 0)
            {
                return Result.Failure<Recipe>("Quantity is mandatory");
            }

            var recipe = new Recipe(name, price, ingredients, available, quantity);

            return Result.Success(recipe);
        }

        public Result<Recipe> Update(string name, int price, string ingredients, bool available, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Recipe>("Name cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(ingredients))
            {
                return Result.Failure<Recipe>("Ingredients cannot be empty");
            }

            if (price == 0)
            {
                return Result.Failure<Recipe>("Price is mandatory");
            }
            if (quantity == 0)
            {
                return Result.Failure<Recipe>("Quantity is mandatory");
            }

            var recipe = new Recipe(name, price, ingredients, available, quantity);

            return Result.Success(recipe);
        }
    }
}
