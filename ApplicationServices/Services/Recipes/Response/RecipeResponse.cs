namespace ApplicationServices.Services.Recipes.Response
{
    public class RecipeResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Ingredients { get; set; }
        public bool Available { get; set; }
        public int Quantity { get; set; }
    }
}
