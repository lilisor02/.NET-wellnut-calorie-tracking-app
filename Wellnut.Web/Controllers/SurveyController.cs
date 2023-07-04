using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wellnut.Data;
using Wellnut.Data.Models;
using Wellnut.Data.Services;

namespace Wellnut.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IUserData db;

        private readonly WellnutContext context;

        public SurveyController(IUserData db, WellnutContext context)
        {
            this.db = db;
            this.context = context;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Survey";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserInformation model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = db.addUserInformation(model.Username, model.Birthday, model.Gender, model.Height, model.Weight, model.WeightGoal, model.ActivityLevel);
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}