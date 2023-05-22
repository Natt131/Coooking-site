using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models.ViewModels
{
    public class RecipeViewModel
    {
        public Recipe Recipe { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public RecipeViewModel()
        {
            Recipe = new Recipe();
            Ingredients = new List<Ingredient>();
        }

    }
}
