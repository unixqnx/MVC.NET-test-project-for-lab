using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

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


		#region

	    public ActionResult Index2(int? id)
        {
            using (testDBEntities context = new testDBEntities())
            {
                ViewBag.Roles = context.Roles.ToList();
            }

            return View(id);
        }

	    public ActionResult Index3(int? id)
        {
            using (testDBEntities context = new testDBEntities())
            {
                ViewBag.Roles = context.Roles.ToList();
            }

            return View(id);
        }

		public JsonResult GetStaffsDataJson(int? id)
        {
			IEnumerable<Staff> staffs;
			using (testDBEntities context = new testDBEntities())
			{
				context.Configuration.LazyLoadingEnabled = false;
				if (id == null)
				{
					staffs = context.Staffs.Include("Role").ToList();
				}
				else
				{
					staffs = context.Staffs.Include("Role").Where(_ => _.Role.id == id).ToList();
				}
			}

			var result =
				staffs.Select(
					_ =>
						new Staff
						{
							id = _.id,
							Name = _.Name,
							RoleId = _.RoleId,
							Role = new Role { id = _.Role.id, roleName = _.Role.roleName}
						}).ToList();
			return Json(result, JsonRequestBehavior.AllowGet);

			//var list = JsonConvert.SerializeObject(staffs, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });
			//return Content(list, "application/json");
        }

		#endregion


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