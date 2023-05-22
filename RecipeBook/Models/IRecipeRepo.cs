using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public interface IRecipeRepo
    {
        IQueryable<Recipe> Recipes { get; }

        void AddRecipe(Recipe recipe);

        Recipe DeleteRecipe(int recipeID);

        List<Recipe> GetRecipeByTime(int cookMin);
        List<Recipe> GetRecipeByCookMinAndCategory(int cookMin, string category);
        List<Recipe> GetAll();
    }
}
