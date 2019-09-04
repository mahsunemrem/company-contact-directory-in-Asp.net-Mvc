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
using XYZContacts.DataAccessLayer.Repositories;
using XYZContacts.Entities;

namespace XYZContacts.WebUI.Controllers
{
    [HandleError]
    [Authorize(Roles = "Admin,Manager,User")]
    public class EmployeeController :  Controller
    {
        private AppIdentityBusiness AIB = new AppIdentityBusiness();
         
        private EmployeeBusiness EB = new EmployeeBusiness();
         
        private DepartmentBusiness DB1 = new DepartmentBusiness();
         
        private TitleBusiness TB = new TitleBusiness();

       
        public ActionResult Index()
        {
           
            return View(EB.GetAll());
        }

       
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = EB.Find((Guid)id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(AIB.GetAll(), "Id", "Username");
            ViewBag.DepartmentId = new SelectList(DB1.GetAll(), "ID", "DepartmentName");
            ViewBag.TitleId = new SelectList(TB.GetAll(), "ID", "TitleName");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,Email,PhoneNumbersI,PhoneNumbersII,DateOfStart,About,DepartmentId,TitleId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                EB.Create(employee);
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(AIB.GetAll(), "Id", "Username", employee.Id);
            ViewBag.DepartmentId = new SelectList(DB1.GetAll(), "ID", "DepartmentName");
            ViewBag.TitleId = new SelectList(TB.GetAll(), "ID", "TitleName");
            return View(employee);
        }

     
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            else
            {
                var employee = EB.Find((Guid)id);

                if (employee == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Id = new SelectList(AIB.GetAll(), "Id", "Username", employee.Id);
                ViewBag.DepartmentId = new SelectList(DB1.GetAll(), "ID", "DepartmentName", employee.DepartmentId);
                ViewBag.TitleId = new SelectList(TB.GetAll(), "ID", "TitleName", employee.TitleId);
                return View(employee);
            }
           
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Email,PhoneNumbersI,PhoneNumbersII,DateOfStart,About,DepartmentId,TitleId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                EB.Edit(employee);              
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(AIB.GetAll(), "Id", "Username", employee.Id);
            ViewBag.DepartmentId = new SelectList(DB1.GetAll(), "ID", "DepartmentName", employee.DepartmentId);
            ViewBag.TitleId = new SelectList(TB.GetAll(), "ID", "TitleName", employee.TitleId);
            return View(employee);
        }

        
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Employee employee = EB.Find((Guid)id);

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            var identity = AIB.Find(id);

            if (identity!=null)
            {
                if ((AIB.First(User.Identity.Name).AppRole.RoleLimit) - identity.AppRole.RoleLimit > 0)
                {
                    AIB.Delete(id);
                    EB.Delete(id);
                                                      
                }

                else return View("_Errors",null, "Yetkiniz bu durum için yeterli değildir !"); 
                
            }

            EB.Delete(id);

            return RedirectToAction("Index");
        }

        
    }
}
