using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            IEnumerable<Staff> staffs;

            using (testDBEntities context = new testDBEntities())
            {
                staffs = context.Staffs.Include("Role").ToList();
            }

            return View(staffs);
        }

        public ActionResult Add()
        {
            using (testDBEntities context = new testDBEntities())
            {
                ViewBag.Roles = context.Roles.ToList();
            }
            return View(new Staff());
        }

        [HttpPost]
        public ActionResult Add(Staff staff)
        {
            using (testDBEntities context = new testDBEntities())
            {
                context.Staffs.Add(staff);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }



    }
}