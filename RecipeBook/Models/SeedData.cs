using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RecipeBook.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            
            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        Name = "Chicken Fajitas",
                        Servings = 6,
                        CookMinutes = 40,
                        PrepMinutes = 20,
                        Description = "Seasoned Grilled Chicken and Veg",
                        Directions = "In a large bowl, whisk together 1⁄2 cup oil, lime juice, cumin, and red pepper flakes. Season chicken with salt and pepper, then add to bowl and toss to coat. Let marinate in the fridge at least 30 minutes and up to 2 hours. When ready to cook, heat remaining tablespoon oil in a large skillet over medium heat. Add chicken and cook until golden and cooked through, 8 minutes per side. Let rest 10 minutes, then slice into strips. Add bell peppers and onion to skillet and cook until soft, 5 minutes. Add chicken and toss until combined. Serve with tortillas."
                    },
                    new Recipe
                    {
                        Name = "Steak Fajitas",
                        Servings = 6,
                        CookMinutes = 40,
                        PrepMinutes = 20,
                        Description = "Seasoned Grilled Steak and Veg",
                        Directions = "In a large bowl, whisk together 1⁄2 cup oil, lime juice, cumin, and red pepper flakes. Season steak with salt and pepper, then add to bowl and toss to coat. Let marinate in the fridge at least 30 minutes and up to 2 hours. When ready to cook, heat remaining tablespoon oil in a large skillet over medium heat. Add steak and cook until golden and cooked through, 8 minutes per side. Let rest 10 minutes, then slice into strips. Add bell peppers and onion to skillet and cook until soft, 5 minutes. Add steak and toss until combined. Serve with tortillas."
                    },
                    new Recipe
                    {
                        Name = "Salmon Fajitas",
                        Servings = 6,
                        CookMinutes = 40,
                        PrepMinutes = 20,
                        Description = "Seasoned Grilled Salmon and Veg",
                        Directions = "In a large bowl, whisk together 1⁄2 cup oil, lime juice, cumin, and red pepper flakes. Season salmon with salt and pepper, then add to bowl and toss to coat. Let marinate in the fridge at least 30 minutes and up to 2 hours. When ready to cook, heat remaining tablespoon oil in a large skillet over medium heat. Add salmon and cook until golden and cooked through, 8 minutes per side. Let rest 10 minutes, then slice into strips. Add bell peppers and onion to skillet and cook until soft, 5 minutes. Add steak and toss until combined. Serve with tortillas."
                    }
                );
            }
            if (!context.Ingredients.Any())
            {
                context.Ingredients.AddRange(
                        new Ingredient { Name = "Olive Oil", Unit = "Cup", Amount = .5, RecipeID = 1 },
                                new Ingredient { Name = "Lime Juice", Unit = "Cup", Amount = .25, RecipeID = 1 },
                                new Ingredient { Name = "Cumin", Unit = "Tsp", Amount = 2, RecipeID = 1 },
                                new Ingredient { Name = "Boneless Salmon", Unit = "Lb", Amount = 1, RecipeID = 1 },
                                new Ingredient { Name = "Kosher Salt", Unit = "Pinch", Amount = 1, RecipeID = 1 },
                                new Ingredient { Name = "Red Pepper Flakes", Unit = "Tsp", Amount = .5, RecipeID = 1 },
                                new Ingredient { Name = "Black Pepper", Unit = "Pinch", Amount = 1, RecipeID = 1 },
                                new Ingredient { Name = "Bell Pepper, thinly sliced", Unit = "Whole", Amount = 2, RecipeID = 1 },
                                new Ingredient { Name = "Large Onion, thinly sliced", Unit = "Whole", Amount = 1, RecipeID = 1 },
                                new Ingredient { Name = "Tortillas", Unit = "Steamed", Amount = 12, RecipeID = 1 },
                        new Ingredient { Name = "Olive Oil", Unit = "Cup", Amount = .5, RecipeID = 2 },
                                new Ingredient { Name = "Lime Juice", Unit = "Cup", Amount = .25, RecipeID = 2 },
                                new Ingredient { Name = "Cumin", Unit = "Tsp", Amount = 2, RecipeID = 1 },
                                new Ingredient { Name = "Thinly Sliced Steak", Unit = "Lb", Amount = 1, RecipeID = 2 },
                                new Ingredient { Name = "Kosher Salt", Unit = "Pinch", Amount = 1, RecipeID = 2 },
                                new Ingredient { Name = "Red Pepper Flakes", Unit = "Tsp", Amount = .5, RecipeID = 2 },
                                new Ingredient { Name = "Black Pepper", Unit = "Pinch", Amount = 1, RecipeID = 2 },
                                new Ingredient { Name = "Bell Pepper, thinly sliced", Unit = "Whole", Amount = 2, RecipeID = 2 },
                                new Ingredient { Name = "Large Onion, thinly sliced", Unit = "Whole", Amount = 1, RecipeID = 2 },
                                new Ingredient { Name = "Tortillas", Unit = "Steamed", Amount = 12, RecipeID = 2 },
                        new Ingredient { Name = "Olive Oil", Unit = "Cup", Amount = .5, RecipeID = 3 },
                                new Ingredient { Name = "Lime Juice", Unit = "Cup", Amount = .25, RecipeID = 3 },
                                new Ingredient { Name = "Cumin", Unit = "Tsp", Amount = 2, RecipeID = 3 },
                                new Ingredient { Name = "Boneless Chicken Breast", Unit = "Lb", Amount = 1, RecipeID = 3 },
                                new Ingredient { Name = "Kosher Salt", Unit = "Pinch", Amount = 1, RecipeID = 3 },
                                new Ingredient { Name = "Red Pepper Flakes", Unit = "Tsp", Amount = .5, RecipeID = 3 },
                                new Ingredient { Name = "Black Pepper", Unit = "Pinch", Amount = 1, RecipeID = 3 },
                                new Ingredient { Name = "Bell Pepper, thinly sliced", Unit = "Whole", Amount = 2, RecipeID = 3 },
                                new Ingredient { Name = "Large Onion, thinly sliced", Unit = "Whole", Amount = 1, RecipeID = 3 },
                                new Ingredient { Name = "Tortillas", Unit = "Steamed", Amount = 12, RecipeID = 3 }
                    );
            }
            context.SaveChanges();
        }
    }
}
