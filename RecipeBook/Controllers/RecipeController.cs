using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;
using RecipeBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using RecipeBook.Migrations;
using System.Web;



namespace RecipeBook.Controllers
{ 

    public class RecipeController : Controller
    {
        private IRecipeRepo repository;
        private IIngredientRepo ingRepository;
       // @"Data Source=DESKTOP-USCN62E\SQLEXPRESS;Initial Catalog=last;Integrated Security=True"
        SqlConnection conn = new SqlConnection(@"Data Source=MSSQLLocalDB;Initial Catalog=RecipeBook;Integrated Security=True");

        //for bd work new 5/04
        private ApplicationDbContext context;
        public RecipeController(IRecipeRepo repo, IIngredientRepo ingRepo)
        {
            repository = repo;
            ingRepository = ingRepo;
        }

        public ViewResult ReviewRecipe() => View();

        [AllowAnonymous]
        public ViewResult Sites()
        {
            return View();
        }


        public IActionResult Catalog()
        {
            return View();
        }
        public IActionResult Recept()
        {
            return View();
        }
        // public ViewResult catal() => View();
        public ViewResult List() => View(repository.Recipes.OrderBy(r => r.Name));
           
        public ViewResult View(int recipeId)
        {
            RecipeViewModel vm = new RecipeViewModel();
            vm.Recipe = repository.Recipes.FirstOrDefault(r => r.RecipeID == recipeId);
            vm.Ingredients = ingRepository.Ingredients.Where(i => i.RecipeID == recipeId)
                .OrderBy(i=>i.IngredientID).ToList();


          // return Json(model);
            return View(vm);
        }

        // беглый просмотр ингридиентов
        [HttpPost]
        public JsonResult ViewModal(int recipeId)
        {
            RecipeViewModel vm = new RecipeViewModel();
            vm.Recipe = repository.Recipes.FirstOrDefault(r => r.RecipeID == recipeId);
            vm.Ingredients = ingRepository.Ingredients.Where(i => i.RecipeID == recipeId)
                .OrderBy(i => i.IngredientID).ToList();

             return Json(vm);
            // return View(vm);
        }

        [HttpGet]
        public JsonResult ViewCookMin(int cookMin)
        {
            List<Models.Recipe> dbEntry = repository.GetRecipeByTime(cookMin);
            return Json(dbEntry);
        }

        [HttpGet]
        public JsonResult ViewCookMinAndCategory(int cookMin, string category)
        {
            List<Models.Recipe> dbEntry = repository.GetRecipeByCookMinAndCategory(cookMin, category);
            return Json(dbEntry);
        }
        [HttpGet]
        public JsonResult ViewAll()
        {
            List<Models.Recipe> dbEntry = repository.GetAll();
            return Json(dbEntry);
        }


        [AllowAnonymous]
        public ViewResult Index()
        {
          //  GreetingTime();
            return View();
        }

        public ViewResult Edit(int recipeId)
        {
            RecipeViewModel recipeViewModel = new RecipeViewModel();
            recipeViewModel.Recipe = repository.Recipes.FirstOrDefault(r => r.RecipeID == recipeId);
            recipeViewModel.Ingredients = ingRepository.Ingredients.Where(i => i.RecipeID == recipeId).ToList();
            ViewBag.InputType = "Edit";
            return View(recipeViewModel);
        }
            
        [HttpPost]
        public IActionResult Edit(RecipeViewModel recipeViewModel)
        {
            if (ModelState.IsValid)
            {
                repository.AddRecipe(recipeViewModel.Recipe);
                foreach(Ingredient i in recipeViewModel.Ingredients)
                {
                    ingRepository.SaveIngredient(i);
                }
                TempData["message"] = $"{recipeViewModel.Recipe.Name} has been updated in your RecipeBook";
                return RedirectToAction("List");
            }
            else
            {
                return View(recipeViewModel);
            }
        }

        /*        [HttpPost]
                public IActionResult Delete(int recipeId)
                {
                    //models. was add 05/04
                    Models.Recipe deletedRecipe = repository.DeleteRecipe(recipeId);
                    List<int> deletables = new List<int>();
                    foreach (Ingredient ing in ingRepository.Ingredients.Where(i=>i.RecipeID == recipeId))
                    {
                        deletables.Add(ing.IngredientID);
                    }
                    foreach(int ingID in deletables)
                    {
                        Ingredient deleteIngredient = ingRepository.DeleteIngredient(ingID);
                    }
                    if(deletedRecipe != null)
                    {
                        TempData["message"] = $"{deletedRecipe.Name} was deleted from your RecipeBook";
                    }
                    return RedirectToAction("List");
                }
        */
        [HttpPost]
        public IActionResult Delete(int recipeId)
        {
            Models.Recipe deletedRecipe = repository.DeleteRecipe(recipeId);
            List<int> deletables = new List<int>();
            foreach (Ingredient ing in ingRepository.Ingredients.Where(i => i.RecipeID == recipeId))
            {
                deletables.Add(ing.IngredientID);
            }
            foreach (int ingID in deletables)
            {
                Ingredient deleteIngredient = ingRepository.DeleteIngredient(ingID);
            }
            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted from your RecipeBook";
            }
            return Json(Url.Action("List", "Recipe"));
            // return RedirectToAction("List");
        }

        public ViewResult Create()
        {
       
            Console.WriteLine("dddddddd");
            RecipeViewModel recipeViewModel = new RecipeViewModel();
            //     Models.Recipe recipeViewModel = new Models.Recipe();

            /*            RecipeViewModel recipeViewModel = new RecipeViewModel();
                        for (int i = 0; i < 5; i++)
                        {
                            recipeViewModel.Ingredients.Add(new Ingredient { RecipeID = recipeViewModel.Recipe.RecipeID });
                        }
            ViewBag.InputType = "Add New";*/
            return View(recipeViewModel); ;
        }

        [HttpPost]
       // public IActionResult CreateRec([FromBody] Models.Recipe recipeViewModel, [FromBody] Models.Ingredient model2)
        public IActionResult CreateRec([FromBody] RecipeViewModel recipeViewModel)
        {
          //  Console.WriteLine(recipeViewModel);
            if (ModelState.IsValid)
            {
                repository.AddRecipe(recipeViewModel.Recipe);
                foreach (Ingredient i in recipeViewModel.Ingredients)
                {
                    i.RecipeID = repository.Recipes.FirstOrDefault(r => r.Name == recipeViewModel.Recipe.Name).RecipeID;
                    ingRepository.SaveIngredient(i);
                }          

                return Json(Url.Action("List", "Recipe"));
            }
            else {
                return Json(Url.Action("Create", "Recipe"));
            

            }
        }


        public JsonResult AjaxMethod( int CookMin)
        {
            Console.WriteLine(CookMin);
            CookMin = 0;
            repository.Recipes.All(r => r.CookMinutes > CookMin);

            return Json(repository.Recipes.All(r => r.CookMinutes > CookMin));
        }
    }

    //method to return greeting based on time
    //public void GreetingTime()
    //    {
    //        int hour = DateTime.Now.Hour;

    //        if (hour >= 5 && hour < 12)
    //            ViewBag.Greeting = "Good Morning";
    //        else if (hour >= 12 && hour < 17)
    //            ViewBag.Greeting = "Good Afternoon";
    //        else if (hour >= 17 && hour < 22)
    //            ViewBag.Greeting = "Good Evening";
    //        else
    //            ViewBag.Greeting = "Good Night";
    //    }
   // }
}
