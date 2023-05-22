using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public int RecipeID { get; set; }
        [Required(ErrorMessage ="Please enter valid name")]
       
  
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter valid Unit of Measure")]
        public string Unit { get; set; }
        [Required]

        [Range(0.25, double.MaxValue,
            ErrorMessage = "Please enter valid Amount")]
        public double Amount { get; set; }

    }
}
