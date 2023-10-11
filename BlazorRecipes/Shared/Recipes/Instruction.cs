using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace BlazorRecipes.Shared.Recipes
{
    public class Instruction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Text { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}