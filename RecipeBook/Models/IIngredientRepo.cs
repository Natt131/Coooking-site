using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public interface IIngredientRepo
    {
        IQueryable<Ingredient> Ingredients { get; }

        void SaveIngredient(Ingredient ingredient);

        Ingredient DeleteIngredient(int ingredientID);
    }
}
