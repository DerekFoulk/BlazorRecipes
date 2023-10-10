namespace BlazorRecipes.Shared.Recipes
{
    public class Details
    {
        public TimeSpan PrepTime { get; set; }
        public TimeSpan CookTime { get; set; }
        public TimeSpan TotalTime => PrepTime + CookTime;
        public int Servings { get; set; }
    }
}