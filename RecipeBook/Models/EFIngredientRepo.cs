using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class EFIngredientRepo : IIngredientRepo
    {
        private ApplicationDbContext context;

        public EFIngredientRepo(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Ingredient> Ingredients => context.Ingredients;

        public void SaveIngredient(Ingredient ingredient)
        {
            if (ingredient.IngredientID == 0)
            {
                context.Ingredients.Add(ingredient);
            }
            else
            {
                Ingredient dbEntry = context.Ingredients
                    .FirstOrDefault(r => r.IngredientID == ingredient.IngredientID);
                if (dbEntry != null)
                {
                    dbEntry.Name = ingredient.Name;
                    dbEntry.Unit = ingredient.Unit;
                    dbEntry.Amount = ingredient.Amount;
                }
            }
            context.SaveChanges();
        }

        public Ingredient DeleteIngredient(int ingredientID)
        {
            Ingredient dbEntry = context.Ingredients
                .FirstOrDefault(r => r.IngredientID == ingredientID);
            if (dbEntry != null)
            {
                context.Ingredients.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
