using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace test.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            IEnumerable<Role> roles;

            using (testDBEntities context = new testDBEntities())
            {
                roles =  context.Roles.ToList();
            }

            return View(roles);
        }


        public ActionResult Edit(int id)
        {
            Role role;
            using (testDBEntities context = new testDBEntities())
            {
                role = context.Roles.Find(id);
            }

            return View(role);
        }


        [HttpPost]
        public ActionResult Edit(Role role)
        {
            using (testDBEntities context = new testDBEntities())
            {
                context.Entry(role).State = EntityState.Modified;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            Role role;
            using (testDBEntities context = new testDBEntities())
            {
                role = context.Roles.Find(id);
            }

            return View(role);
        }


        [HttpPost]
        public ActionResult Delete(Role role)
        {
            using (testDBEntities context = new testDBEntities())
            {
                context.Entry(role).State = EntityState.Deleted;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }








    }
}