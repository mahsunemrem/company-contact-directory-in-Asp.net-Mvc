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
    public class DepartmentsController : Controller
    {
        
        private DepartmentBusiness DB = new DepartmentBusiness();

   
        public ActionResult Index()
        {
            return View(DB.GetAll());
        }

       
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var department = DB.Find((Guid)id);

            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                DB.Create(department);
                return RedirectToAction("Index");
            }

            return View(department);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var department = DB.Find((Guid)id);

            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                DB.Edit(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var department = DB.Find((Guid)id);

            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            if (DB.Find(id).Employees.Count()>0)
            {
                var errors= "Bu Departman da çalışan insanlar olduğu için silinemez";
                return View("_Errors", null,errors);
            }

            DB.Delete(id);
            return RedirectToAction("Index");
        }

      
    }
}
