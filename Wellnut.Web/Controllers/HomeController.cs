using Microsoft.Ajax.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using System.Windows.Media.Imaging;
using Wellnut.Data;
using Wellnut.Data.Enums;
using Wellnut.Data.Models;
using Wellnut.Data.Services;

namespace Wellnut.Web.Controllers
{
    public class HomeController : Controller
    {
        MealDbService _mealDb = new MealDbService();

        public ActionResult Index()
        {
            //var recipes = _mealDb.GetRecipies(Category.Seafood).GetAwaiter().GetResult();

            //foreach (RecipeApiModel recipe in recipes)
            //{
            //    //Console.WriteLine(recipe.Title);
            //    //ViewBag.RecipesfromApi = recipes;
            //    var recipePicture = (Bitmap)((new ImageConverter()).ConvertFrom(recipe.Picture));
            //    recipe.Picture = recipePicture;
            //}

            //return View(recipes);
            return View();
        }

        public ActionResult User()
        {
            //var categories = _mealDb.GetAllCategories().GetAwaiter().GetResult();

            //var ingredient = _mealDb.GetAllCategories().GetAwaiter().GetResult();

            return View();
        }

        public ActionResult Recipe(int id)
        {
            var recipeById = _mealDb.GetRecipeById(id).GetAwaiter().GetResult();

            return View(recipeById);
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult User(string searchTermCategory, string searchTermArea, string searchTermIngredient, string searchType, RecipeApiModel model)
        {
            var recipes = _mealDb.GetRecipiesByCategory(searchTermCategory, searchTermArea, searchTermIngredient, searchType).GetAwaiter().GetResult();

            if(recipes != null)
            {
                return View(recipes);
            }
            else
            {
                return View();
            }
            


        }


        public JsonResult getAllCategories()
        {
            var categories = _mealDb.GetAllCategories().GetAwaiter().GetResult();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getAllAreas()
        {
            var areas = _mealDb.GetAllAreas().GetAwaiter().GetResult();

            return Json(areas, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getAllIngredients()
        {
            var ingredients = _mealDb.GetAllIngredients().GetAwaiter().GetResult();

            return Json(ingredients, JsonRequestBehavior.AllowGet);
        }

    }
}