using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
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

		private int? ReadSession(int? id)
		{
			id = Session["roleId"] as int?;
			return id;
		}

		private int? WriteSession(int? id)
		{
			Session["roleId"] = id;
			return id;
		}

		private int? ReadCookie(int? id)
		{
			HttpCookie cookie = Request.Cookies["TestApplication"];

			if (cookie != null)
			{
				int value;
				string roleString = cookie["roleId"];

				if (int.TryParse(roleString, out value))
				{
					id = value;
				}
			}

			return id;
		}

		private int? WriteCookie(int? id)
		{
			HttpCookie cookie = new HttpCookie("TestApplication");
			cookie["roleId"] = id.ToString();
			cookie.Expires = DateTime.Now.AddYears(1);
			Response.Cookies.Add(cookie);
			return id;
		}

		#region

	    public ActionResult Index2(int? id)
        {
            using (testDBEntities context = new testDBEntities())
            {
                ViewBag.Roles = context.Roles.ToList();
            }

			//id = ReadCookie(id);
			id = ReadSession(id);

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
			//id = WriteCookie(id);
			id = WriteSession(id);

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