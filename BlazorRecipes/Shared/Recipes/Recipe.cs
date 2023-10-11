namespace BlazorRecipes.Shared.Recipes
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();
        public ICollection<Instruction>? Instructions { get; set; } = new List<Instruction>();
        public Details? Details { get; set; }
    }
}
