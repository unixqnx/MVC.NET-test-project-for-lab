using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationTest.Models;

namespace ValidationTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult MakeBooking()
        {
            return View(new Appointment { Date= DateTime.Now });
        }

        //[HttpPost]
        //public ActionResult MakeBooking(Appointment app)
        //{
        //    return View("Completed", app);
        //}


        //[HttpPost]
        //public ActionResult MakeBooking(Appointment app)
        //{
        //    if(ModelState.IsValidField("ClientName") && ModelState.IsValidField("Date")
        //        && app.ClientName == "Вася" && app.Date.DayOfWeek == DayOfWeek.Monday)
        //            ModelState.AddModelError("", "Васи по понедельникам отдыхают!");

        //    if (string.IsNullOrEmpty(app.ClientName))
        //        ModelState.AddModelError("ClientName", "Введите своё имя");

        //    if(ModelState.IsValidField("Date") && DateTime.Now > app.Date)
        //        ModelState.AddModelError("Date", "Введите дату относящуюся к будущему");

        //    if(!app.TermsAccepted)
        //        ModelState.AddModelError("TermsAccepted", "Вы должны принять условия");


        //    if (ModelState.IsValid)
        //    {
        //        return View("Completed", app);
        //    }

        //    return View();
        //}


        [HttpPost]
        public ActionResult MakeBooking(Appointment app)
        {
            if (ModelState.IsValid)
            {
                return View("Completed", app);
            }

            return View();
        }


        public JsonResult ValidateDate(string date)
        {
            DateTime parsedDate;

            if (!DateTime.TryParse(date, out parsedDate))
            {
                return Json("Пожалуйста, введите дату в формате (дд.мм.гггг)", JsonRequestBehavior.AllowGet);
            }
            else if (DateTime.Now > parsedDate)
            {
                return Json("Введите дату относящуюся к будущему", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

        }



    }
}