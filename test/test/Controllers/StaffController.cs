using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace test.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index(int? id)
        {
            using (testDBEntities context = new testDBEntities())
            {
                ViewBag.Roles = context.Roles.ToList();
            }

            return View(id);
        }


        //[ChildActionOnly]
        public ActionResult GetStaffs(int? id)
        {
            IEnumerable<Staff> staffs;
            using (testDBEntities context = new testDBEntities())
            {
                if (id == null)
                {
                    staffs = context.Staffs.Include("Role").ToList();
                }
                else
                {
                    staffs = context.Staffs.Include("Role").Where(_ => _.Role.id == id).ToList();
                }
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