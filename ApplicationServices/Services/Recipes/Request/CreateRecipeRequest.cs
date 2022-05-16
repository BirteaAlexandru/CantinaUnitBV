namespace ApplicationServices.Services.Recipes.Request
{
    public class CreateRecipeRequest
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Ingredients { get; set; }
        public bool Available { get; set; }
        public int Quantity { get; set; }
    }
}
