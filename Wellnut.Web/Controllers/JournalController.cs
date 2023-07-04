using Microsoft.Ajax.Utilities;
using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Wellnut.Data;
using Wellnut.Data.Models;
using Wellnut.Data.Services;
using Wellnut.Web.Models;

namespace Wellnut.Web.Controllers

{
    public class JournalController : Controller
    {
        private readonly IFoodData db;

        private readonly WellnutContext context;

        public JournalController(IFoodData db, WellnutContext context)
        {
            this.db = db;
            this.context = context;

        }
        public ActionResult Index()
        {
            var historyData = getUserHistory();

            if(historyData.Count == 0)
            {
                ViewBag.historyCount = 0;
            }

            return View(historyData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string searchTerm, UserHistory model)
        {
            if (!searchTerm.IsEmpty())
            {

                var food = context.Food.Where(x => x.FoodName.Equals(searchTerm)).ToList();

                ViewBag.SearchTerm = food;
                
                if (food.Count == 0)
                {
                    var userId = Convert.ToInt32(Session["userId"]);
                    return View();
                }
                else
                {
                    var userId = Convert.ToInt32(Session["userId"]);

                    System.Web.HttpContext.Current.Session["foodId"] = food[0].FoodId;
                    var foodId = Convert.ToInt32(System.Web.HttpContext.Current.Session["foodId"]);

                    if (ModelState.IsValid)
                    {
                        int recordsCreated = db.addFoodHistory(model.JournalDate, model.ServingSize, userId, foodId);

                        var historyData = getUserHistory();

                        return View(historyData);
                    }
                }

            }
            return View();
        }

        public JsonResult getAllFoods()
        {
            List<Food> listOfFoods = context.Food.ToList();
            //List<Recipe> listOfRecipes = context.Recipe.ToList();

            //List<object> all = listOfFoods.Cast<object>().Concat(listOfRecipes).ToList();

            return Json(listOfFoods, JsonRequestBehavior.AllowGet);
        }



        public ICollection getUserHistory()
        {
            var query = context.UserHistory
                    .Join(context.UserInformation, h => h.UserInformationId,
                      i => i.UserInformationId, (h, i) => new
                      {
                          i.UserInformationId,
                          h.JournalDate,
                          h.ServingSize,
                          h.FoodId,
                          h.UserHistoryId
                      })
                    .Join(context.Food, h => h.FoodId, f => f.FoodId, (h, f) => new JournalViewModel
                    {
                        UserHistoryId = h.UserHistoryId,
                        UserInformationId = h.UserInformationId,
                        JournalDate = h.JournalDate,
                        ServingSize = h.ServingSize,
                        FoodId = f.FoodId,
                        FoodName = f.FoodName,
                        Calories = f.Calories,
                        Protein = f.Protein,
                        Carbs = f.Carbs,
                        Fat = f.Fat
                    }).ToList();

            var historyData = query.Where(x => x.JournalDate == DateTime.Today && x.UserInformationId == (int)Session["userId"]).ToList();


            return historyData;

        }


        public ActionResult Delete(int id)
        {
            var userId = Convert.ToInt32(Session["userId"]);

            var data = context.UserHistory.FirstOrDefault(x => x.UserHistoryId == id);
            context.UserHistory.Remove(data);

            context.SaveChanges();

            var historyData = getUserHistory();

            return RedirectToAction("Index", "Journal", new { id = userId });
        }

        public ActionResult Edit(int id)
        {
            ViewBag.UserHistoryId = id;

            var historyData = getUserHistory();

            var data = context.UserHistory.Where(x => x.UserHistoryId == id).FirstOrDefault();

            return View("_EditJournal", historyData);
        }

        [HttpPost]
        public ActionResult Edit(UserHistory model, int id)
        {
            ViewBag.UserHistoryId = id;
            var data = context.UserHistory.FirstOrDefault(x => x.UserHistoryId == id);

            data.ServingSize = model.ServingSize;

            context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}



