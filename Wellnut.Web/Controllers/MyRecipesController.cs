using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wellnut.Data.Services;
using Wellnut.Data;
using System.Collections;
using Wellnut.Web.Models;
using System.Web.WebPages;
using Wellnut.Data.Models;
using System.Security.Permissions;
using Microsoft.Ajax.Utilities;
using System.Web.Http.Results;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace Wellnut.Web.Controllers
{
    public class MyRecipesController : Controller
    {
        private readonly IFoodData db;

        private readonly WellnutContext context;

        public MyRecipesController(IFoodData db, WellnutContext context)
        {
            this.db = db;
            this.context = context;

        }

        // GET: MyRecipes
        public ActionResult Index()
        {
            var recipeData = getRecipeData();

            if(recipeData.Count == 0)
            {
                ViewBag.RecipeCount = 0;
            }
           

            return View(recipeData);

        }

        public ActionResult CreateRecipe()
        {

            //var ingredientsData = getIngredientsForARecipe(@Session["recipeName"].ToString());

            //var ingredients = Session["ingredientsForNewRecipe"];
            //ViewBag.RecipeName = name;
            //var ingredientsData = getLastRecipeIngredients(model);

            //return View(ingredientsData);

            return View();
        }

        public ActionResult _EditRecipe()
        {
            var recipeData = getRecipeData();

            return View(recipeData);
        }


        public ActionResult _CreateRecipeReadonly()
        {
            
            var ingredientsData = getIngredientsForARecipe(@Session["recipeName"].ToString());

            //var ingredients = Session["ingredientsForNewRecipe"];
            //ViewBag.RecipeName = name;
            //var ingredientsData = getLastRecipeIngredients(model);

            return View(ingredientsData);

            //var recipeData = getRecipeData();

            //return View(recipeData);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRecipe(string searchTerm, Recipe model)
        {
            if (!searchTerm.IsEmpty())
            {
                var food = context.Food.Where(x => x.FoodName.Equals(searchTerm)).ToList();

                if (food != null)
                {
                    ViewBag.SearchTerm = food;
                }

                if (food.Count == 0)
                {
                    var userId = Convert.ToInt32(Session["userId"]);
                    return View();
                }
                else
                {
                    var userId = Convert.ToInt32(Session["userId"]);

                    System.Web.HttpContext.Current.Session["foodRecipeId"] = food[0].FoodId;
                    var foodRecipeId = Convert.ToInt32(System.Web.HttpContext.Current.Session["foodRecipeId"]);

                    System.Web.HttpContext.Current.Session["recipeName"] = model.RecipeName;

                    //var recipe = context.Recipe.Where(x => x.RecipeName.Equals(model.RecipeName)).ToList();

                    //if(recipe.Count > 0)
                    //{
                    //    ViewBag.RecipeAlreadyInDb = 1;

                    //}
                    if (ModelState.IsValid)
                    {
                        int recordsCreated = db.addRecipeDb(model.RecipeName, model.ServingSize, foodRecipeId, userId);

                        var ingredientData = getIngredientsForARecipe(model.RecipeName);

                        return View("_CreateRecipeReadonly", ingredientData);
                    }
                }
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _CreateRecipeReadonly(string searchTerm, Recipe model)
        {
            if (!searchTerm.IsEmpty())
            {
                var food = context.Food.Where(x => x.FoodName.Equals(searchTerm)).ToList();

                if (food != null)
                {
                    ViewBag.SearchTerm = food;
                }

                if (food.Count == 0)
                {
                    var userId = Convert.ToInt32(Session["userId"]);
                    return View();
                }
                else
                {
                    var userId = Convert.ToInt32(Session["userId"]);

                    System.Web.HttpContext.Current.Session["foodRecipeId"] = food[0].FoodId;
                    var foodRecipeId = Convert.ToInt32(System.Web.HttpContext.Current.Session["foodRecipeId"]);

                    System.Web.HttpContext.Current.Session["recipeName"] = model.RecipeName;

                    //var recipe = context.Recipe.Where(x => x.RecipeName.Equals(model.RecipeName)).ToList();

                    //if(recipe.Count > 0)
                    //{
                    //    ViewBag.RecipeAlreadyInDb = 1;

                    //}
                    if (ModelState.IsValid)
                    {
                        int recordsCreated = db.addRecipeDb(model.RecipeName, model.ServingSize, foodRecipeId, userId);

                        var ingredientData = getIngredientsForARecipe(model.RecipeName);

                        return View("_CreateRecipeReadonly", ingredientData);
                    }
                }
            }

            return View();
        }

        public ICollection getRecipeData()
        {
            var query = context.Recipe
                    .Join(context.UserInformation, h => h.UserInformationId,
                      i => i.UserInformationId, (h, i) => new
                      {
                          i.UserInformationId,
                          h.RecipeName,
                          h.ServingSize,
                          h.FoodId,
                          h.RecipeId
                      })
                    .Join(context.Food, h => h.FoodId, f => f.FoodId, (h, f) => new MyRecipesViewModel
                    {
                        RecipeId = h.RecipeId,
                        RecipeName = h.RecipeName,
                        UserInformationId = h.UserInformationId,
                        ServingSize = h.ServingSize,
                        FoodId = f.FoodId,
                        FoodName = f.FoodName,
                        Calories = f.Calories,
                        Protein = f.Protein,
                        Carbs = f.Carbs,
                        Fat = f.Fat
                    }).ToList();

            var ingredientsData = query.Where(x => x.UserInformationId == (int)Session["userId"]).GroupBy(x => x.RecipeName).Select(x => x.FirstOrDefault()).ToList();

            return ingredientsData;

        }

        public ICollection getIngredients()
        {
            var query = context.Recipe
                    .Join(context.UserInformation, h => h.UserInformationId,
                      i => i.UserInformationId, (h, i) => new
                      {
                          i.UserInformationId,
                          h.RecipeName,
                          h.ServingSize,
                          h.FoodId,
                          h.RecipeId
                      })
                    .Join(context.Food, h => h.FoodId, f => f.FoodId, (h, f) => new MyRecipesViewModel
                    {
                        RecipeId = h.RecipeId,
                        RecipeName = h.RecipeName,
                        UserInformationId = h.UserInformationId,
                        ServingSize = h.ServingSize,
                        FoodId = f.FoodId,
                        FoodName = f.FoodName,
                        Calories = f.Calories,
                        Protein = f.Protein,
                        Carbs = f.Carbs,
                        Fat = f.Fat
                    }).ToList();


            var ingredientsData = query.Where(x => x.UserInformationId == (int)Session["userId"]).GroupBy(x => x.RecipeName).Select(x => x).SelectMany(x => x).ToList();

            return ingredientsData;

        }

        public ICollection getIngredientsForARecipe(string nume)
        {
            var query = context.Recipe
                    .Join(context.UserInformation, h => h.UserInformationId,
                      i => i.UserInformationId, (h, i) => new
                      {
                          i.UserInformationId,
                          h.RecipeName,
                          h.ServingSize,
                          h.FoodId,
                          h.RecipeId
                      })
                    .Join(context.Food, h => h.FoodId, f => f.FoodId, (h, f) => new MyRecipesViewModel
                    {
                        RecipeId = h.RecipeId,
                        RecipeName = h.RecipeName,
                        UserInformationId = h.UserInformationId,
                        ServingSize = h.ServingSize,
                        FoodId = f.FoodId,
                        FoodName = f.FoodName,
                        Calories = f.Calories,
                        Protein = f.Protein,
                        Carbs = f.Carbs,
                        Fat = f.Fat
                    }).ToList();


            var ingredientsData = query.Where(x => x.UserInformationId == (int)Session["userId"] && x.RecipeName == nume).GroupBy(x => x.RecipeName).Select(x => x).SelectMany(x => x).ToList();

            return ingredientsData;

        }

        public ICollection getLastRecipeIngredients(Recipe model)
        {
            var query = context.Recipe
                    .Join(context.UserInformation, h => h.UserInformationId,
                      i => i.UserInformationId, (h, i) => new
                      {
                          i.UserInformationId,
                          h.RecipeName,
                          h.ServingSize,
                          h.FoodId,
                          h.RecipeId
                      })
                    .Join(context.Food, h => h.FoodId, f => f.FoodId, (h, f) => new MyRecipesViewModel
                    {
                        RecipeId = h.RecipeId,
                        RecipeName = h.RecipeName,
                        UserInformationId = h.UserInformationId,
                        ServingSize = h.ServingSize,
                        FoodId = f.FoodId,
                        FoodName = f.FoodName,
                        Calories = f.Calories,
                        Protein = f.Protein,
                        Carbs = f.Carbs,
                        Fat = f.Fat
                    }).ToList();

            var recipeData = query.Where(x => x.UserInformationId == (int)Session["userId"] && x.RecipeName == model.RecipeName).ToList();


            return recipeData;
        }

        public JsonResult getAllRecipes()
        {
            List<Recipe> listOfRecipes = context.Recipe.GroupBy(x => x.RecipeName).Select(x => x.FirstOrDefault()).ToList();

            return Json(listOfRecipes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string name, Recipe model)
        {

            var data = context.Recipe.Where(x => x.RecipeName == name).ToList();
            context.Recipe.RemoveRange(data);

            context.SaveChanges();

            var historyData = getLastRecipeIngredients(model);

            return RedirectToAction("Index", "MyRecipes");

            //return RedirectToAction("_EditRecipe", "MyRecipes", new { name = name }); !!!!

        }

        public ActionResult DeleteIngredient(int recipeId, int foodId, Recipe model)
        {
            var data = context.Recipe.Where(x => x.RecipeId == recipeId && x.FoodId == foodId).ToList();
            context.Recipe.RemoveRange(data);

            context.SaveChanges();

            var ingredientsData = getIngredients();

            //if (ingredientsData.Count() == 0)
            //{
            //    return RedirectToAction("Index", "MyRecipes");

            //}
            //else
            //{
                return View("_EditRecipe", ingredientsData);

            //}

            //return RedirectToAction("Index", "MyRecipes");
            //return RedirectToAction("_EditRecipe", "MyRecipes", new { name = name }); !!!!

        }

        public ActionResult Edit(string name)
        {
            //var ingredientsData = getIngredients();
            var ingredientsData = getIngredientsForARecipe(name);

            var data = context.Recipe.Where(x => x.RecipeName == name);

            ViewBag.RecipeName = name;

            return View("_EditRecipe", ingredientsData);
        }

        public ActionResult EditIngredient(int id, string name)
        {
            ViewBag.RecipeId = id;
            ViewBag.IngredientName = name;
            var ingredientsData = getIngredients();

            var data = context.Recipe.Where(x => x.FoodId == id).ToList();

            return View("EditIngredient", ingredientsData);
        }

        [HttpPost]
        public ActionResult EditIngredient(MyRecipesViewModel model, int id, string name)
        {

            var data = context.Recipe.FirstOrDefault(x => x.RecipeId == id);
            var recipeName = context.Recipe.FirstOrDefault(x => x.RecipeId == id).RecipeName;

            ViewBag.RecipeName = recipeName;

            data.ServingSize = model.ServingSize;

            context.SaveChanges();

            var ingredientsData = getIngredients();

            return View("_EditRecipe", ingredientsData);
        }

        public ActionResult Details(string name)
        {
            //var ingredientsData = getIngredients();
            var ingredientsData = getIngredientsForARecipe(name);

            ViewBag.RecipeName = name;

            return View("_DetailsRecipe", ingredientsData);
        }

        public ActionResult EditNewRecipe(int id, string name)
        {
            ViewBag.RecipeId = id;
            ViewBag.RecipeName = name;

            //var ingredientsData = getIngredients();
            var ingredientsData = getIngredientsForARecipe(name);

            //Session["ingredientsForNewRecipe"] = ingredientsData;
            var data = context.Recipe.Where(x => x.RecipeName == name);

            ViewBag.RecipeName = name;

            return View("EditNewRecipe", ingredientsData);
        }


        [HttpPost]
        public ActionResult EditNewRecipe(MyRecipesViewModel model, int id, string name)
        {

            var data = context.Recipe.FirstOrDefault(x => x.RecipeId == id);
            var recipeName = context.Recipe.FirstOrDefault(x => x.RecipeId == id).RecipeName;

            @ViewBag.RecipeName = recipeName;

            data.ServingSize = model.ServingSize;

            context.SaveChanges();

            var ingredientsData = getIngredientsForARecipe(name);

            Session["ingredientsForNewRecipe"] = ingredientsData;

            return RedirectToAction("_CreateRecipeReadonly");
            
        }

        public ActionResult DeleteIngredientNewRecipe(int recipeId, int foodId, Recipe model)
        {
            var data = context.Recipe.Where(x => x.RecipeId == recipeId && x.FoodId == foodId).ToList();
            var recipeName = context.Recipe.FirstOrDefault(x => x.RecipeId == recipeId).RecipeName;
            context.Recipe.RemoveRange(data);

            context.SaveChanges();

            var ingredientsData = getIngredientsForARecipe(recipeName);


            //if(ingrecients.Count() == 0)
            //{
            //    return RedirectToAction("Index", "MyRecipes");

            //} elsesss
            //{
            return RedirectToAction("_CreateRecipeReadonly");

            //}

            //return RedirectToAction("Index", "MyRecipes");
            //return RedirectToAction("_EditRecipe", "MyRecipes", new { name = name }); !!!!

        }
    }
}