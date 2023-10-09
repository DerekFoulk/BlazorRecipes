namespace BlazorRecipes.Shared.Recipes
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; }
        public ICollection<Instruction>? Instructions { get; set; }
        public Details? Details { get; set; }
    }
}
