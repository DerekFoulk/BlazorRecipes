using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlazorRecipes.Shared.Recipes
{
    public class Details
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(typeof(TimeSpan), "00:00", "12:00")]
        public TimeSpan PrepTime { get; set; }

        [Required]
        [Range(typeof(TimeSpan), "00:00", "72:00")]
        public TimeSpan CookTime { get; set; }

        [JsonIgnore]
        [NotMapped]
        public TimeSpan TotalTime => PrepTime + CookTime;

        [MinLength(1), MaxLength(20)]
        public int Servings { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}