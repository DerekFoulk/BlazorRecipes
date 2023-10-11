using System.ComponentModel.DataAnnotations;

namespace BlazorRecipes.Shared.Recipes
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }
        
        [MaxLength(255)]
        public string? Description { get; set; }
        
        [MaxLength(255)]
        [Required]
        public string? Image { get; set; }

        [MinLength(1), MaxLength(50)]
        public ICollection<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();

        [MinLength(1), MaxLength(50)]
        public ICollection<Instruction>? Instructions { get; set; } = new List<Instruction>();

        [Required]
        public Details? Details { get; set; }
    }
}
