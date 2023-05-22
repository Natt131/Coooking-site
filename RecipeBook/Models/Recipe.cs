using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        [Required(ErrorMessage = "Please Enter a Recipe Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter a Recipe Description")]
        public string Description { get; set; }
        [Required]
        [Range(1,500,ErrorMessage = "Please Enter Number of Servings")]
        public int Servings { get; set; }
        [Required]
        [Range(0, 2880, ErrorMessage = "Please Enter Number Cooking Minutes")]
        public int CookMinutes { get; set; }
        [Required]
        [Range(0, 2880, ErrorMessage = "Please Enter Number of Prep Minutes")]
        public int PrepMinutes { get; set; }
        [Required(ErrorMessage = "Please Enter Directions")]
        public string Directions { get; set; }

        //new
        public string Category { get; set; }
        
    }
}
