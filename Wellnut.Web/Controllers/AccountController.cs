using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wellnut.Data.Services;
using Wellnut.Data;
using Wellnut.Web.Models;
using Wellnut.Data.Models;

namespace Wellnut.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserData db;

        private readonly WellnutContext context;

        public AccountController(IUserData db, WellnutContext context)
        {
            this.db = db;
            this.context = context;
        }

        // GET: Account
        public ActionResult Index()
        {
            var userLoggedIn = (int)Session["userId"];
            var userInformation = context.UserInformation.Where(x => x.UserInformationId == userLoggedIn).FirstOrDefault();

            AccountViewModel accountViewModel = new AccountViewModel();
            accountViewModel.Username = userInformation.Username;
            accountViewModel.Gender = userInformation.Gender;
            accountViewModel.Height = userInformation.Height;
            accountViewModel.Weight = userInformation.Weight;
            accountViewModel.WeightGoal = userInformation.WeightGoal;
            accountViewModel.ActivityLevel = userInformation.ActivityLevel;

            return View(accountViewModel);

        }

        public ActionResult Edit()
        {
            var userLoggedIn = (int)Session["userId"];
            var userInformation = context.UserInformation.Where(x => x.UserInformationId == userLoggedIn).FirstOrDefault();

            AccountViewModel accountViewModel = new AccountViewModel();
            accountViewModel.Username = userInformation.Username;
            accountViewModel.Gender = userInformation.Gender;
            accountViewModel.Height = userInformation.Height;
            accountViewModel.Weight = userInformation.Weight;
            accountViewModel.WeightGoal = userInformation.WeightGoal;
            accountViewModel.ActivityLevel = userInformation.ActivityLevel;

            return View("_EditAccount", accountViewModel);
        }


        [HttpPost]
        public ActionResult Edit(UserInformation userInformation)
        {
            var userLoggedIn = (int)Session["userId"];
            var data = context.UserInformation.FirstOrDefault(x => x.UserInformationId == userLoggedIn);

            data.Username = userInformation.Username;
            data.Gender = userInformation.Gender;
            data.Height = userInformation.Height;
            data.Weight = userInformation.Weight;
            data.WeightGoal = userInformation.WeightGoal;
            data.ActivityLevel = userInformation.ActivityLevel;


            context.SaveChanges();

            ViewBag.UpdateSucces = 1;


            return View("Index");
        }


    }


}