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
    [Authorize(Roles ="Admin")]
    public class AppIdentityController : Controller
    {
        private DataContext db = new DataContext();
        private AppIdentityBusiness AIB = new AppIdentityBusiness();
        private EmployeeBusiness EB = new EmployeeBusiness();
        private AppRoleBusiness ARB = new AppRoleBusiness();
       
        public ActionResult Index()
        {
        
            return View(AIB.GetAll());
        }

 
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appIdentity = AIB.Find((Guid)id);

            if (appIdentity == null)
            {
                return HttpNotFound();
            }

            return View(appIdentity);
        }

        public ActionResult Create()
        {
            

            ViewBag.AppRoleId = new SelectList(ARB.GetAll(), "ID", "RoleName");
            ViewBag.Id = new SelectList(EB.GetAll().Where(i => i.AppIdentity==null).OrderBy(i => i.Name), "Id", "Name");
            
            return View();
        }

        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,IdentityState,AppRoleId")] AppIdentity appIdentity)
        {
            if (ModelState.IsValid)
            {
                AIB.Create(appIdentity);
                return RedirectToAction("Index");
            }

            return  RedirectToAction("Create"); // check it
           
            ViewBag.AppRoleId = new SelectList(ARB.GetAll(), "ID", "RoleName");
            ViewBag.Id = new SelectList(EB.GetAll().Where(i => i.AppIdentity.Id==null).OrderBy(i => i.Name), "Id", "Name");

          
            return View(appIdentity);
        }

  
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appIdentity = AIB.Find((Guid)id);

            if (appIdentity == null)
            {
                return HttpNotFound();
            }
            //ViewBag.AppRoleId = new SelectList(db.AppRoles, "ID", "RoleName", appIdentity.AppRoleId);
            ViewBag.AppRoleId = new SelectList(ARB.GetAll(), "ID", "RoleName", appIdentity.AppRoleId);
            return View(appIdentity);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,IdentityState,AppRoleId")] AppIdentity appIdentity)
        {
            if (ModelState.IsValid)
            {
                AIB.Edit(appIdentity);
                return RedirectToAction("Index");
            }
            //ViewBag.AppRoleId = new SelectList(db.AppRoles, "ID", "RoleName", appIdentity.AppRoleId);
            ViewBag.AppRoleId = new SelectList(ARB.GetAll(), "ID", "RoleName", appIdentity.AppRoleId);
            return View(appIdentity);
        }

    

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var appIdentity = AIB.Find((Guid)id);

            if (appIdentity == null)
            {
                return HttpNotFound();
            }
            return View(appIdentity);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            if (AIB.Find(id).Username == AIB.First(User.Identity.Name).Username) 
            {
                return View("_Errors", null, "Kendi kendinizi silemezsiniz");
            }

            AIB.Delete(id);
            return RedirectToAction("Index");
        }

      
    }
}
