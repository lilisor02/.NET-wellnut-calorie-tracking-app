using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Syncfusion.Pdf.Grid;
using System.Data;
using Wellnut.Web.Models;
using System.Collections;
using Wellnut.Data.Services;
using Wellnut.Data;
using Microsoft.Ajax.Utilities;
using System.Data.SqlTypes;
using System.IO;

namespace Wellnut.Web.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IUserData db;

        private readonly WellnutContext context;

        public StatisticsController(IUserData db, WellnutContext context)
        {
            this.db = db;
            this.context = context;
        }

        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePDFDocument(ReportViewModel model)
        {
            var data = getUserHistory(model.ReportStartDate, model.ReportEndDate);

            generatePdf();

            return RedirectToAction("Index");
        }

        public ICollection getUserHistory(DateTime startDate, DateTime endDate)
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

            var historyData = query.Where(x => x.JournalDate >= startDate.Date && x.JournalDate <= endDate.Date && x.UserInformationId == (int)Session["userId"]).OrderBy(t => t.JournalDate).ToList();


            return historyData;

        }

        public void generatePdf()
        {
            //Create a new PDF document
            PdfDocument doc = new PdfDocument();
            //Add a page to the document
            PdfPage page = doc.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;
            //Load the image from the disk
            FileStream imageStream = new FileStream("wellnut-logo.png", FileMode.Open, FileAccess.Read);

            PdfBitmap image = new PdfBitmap(imageStream);
            //Draw the image
            graphics.DrawImage(image, new RectangleF(180, 15, 150, 100));

            //Creating the stream object
            MemoryStream stream = new MemoryStream();

            doc.Save(stream);
            doc.Save("Output.pdf", HttpContext.ApplicationInstance.Response, HttpReadType.Save);

            //Close the document
            doc.Close(true);
        }
    }
}