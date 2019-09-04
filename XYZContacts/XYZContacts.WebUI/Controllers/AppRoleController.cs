using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XYZContacts.BusinessLogicLayer;
using XYZContacts.DataAccessLayer.Context;
using XYZContacts.Entities;

namespace XYZContacts.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AppRoleController : Controller
    {
        private AppRoleBusiness ARB = new AppRoleBusiness();

     
        public ActionResult Index()
        {
            return View(ARB.GetAll().ToList());
        }


        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appRole = ARB.Find((Guid)id);

            if (appRole == null)
            {
                return HttpNotFound();
            }
            return View(appRole);
        }

      
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles ="s")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RoleName,Description,RoleLimit")] AppRole appRole)
        {
            if (ModelState.IsValid)
            {
                ARB.Create(appRole);
                return RedirectToAction("Index");
            }

            return View(appRole);
        }


        [Authorize(Roles = "s")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appRole = ARB.Find((Guid)id);

            if (appRole == null)
            {
                return HttpNotFound();
            }
            return View(appRole);
        }


        [Authorize(Roles = "s")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RoleName,Description,RoleLimit")] AppRole appRole)
        {
            if (ModelState.IsValid)
            {
                ARB.Edit(appRole);
                return RedirectToAction("Index");
            }
            return View(appRole);
        }


        [Authorize(Roles = "s")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appRole = ARB.Find((Guid)id);

            if (appRole == null)
            {
                return HttpNotFound();
            }
            return View(appRole);
        }


        [Authorize(Roles = "s")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            ARB.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
