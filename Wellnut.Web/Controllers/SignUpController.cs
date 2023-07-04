using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wellnut.Data;
using Wellnut.Data.Models;
using Wellnut.Data.Services;
using Wellnut.Web.Models;

namespace Wellnut.Web.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IUserData db;

        private readonly WellnutContext context;

        public SignUpController(IUserData db, WellnutContext context)
        {
            this.db = db;
            this.context = context;
        }

        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SignUpViewModel model)
        {
            Boolean status = context.Credentials.Any(x => x.Email == model.Email);

            if (status == true)
            {
                ViewBag.SignUpStatus = 1;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    int recordsCreated = db.addCredentials(model.Email, model.Password);
                    return RedirectToAction("Index", "Survey");

                }
            }

            return View();

        }
    }
}