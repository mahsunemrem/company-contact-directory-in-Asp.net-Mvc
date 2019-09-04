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
    public class TitlesController : Controller
    {      
        private TitleBusiness TB = new TitleBusiness();

        public ActionResult Index()
        {
            return View(TB.GetAll());
        }

        
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var title = TB.Find((Guid)id);

            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TitleName")] Title title)
        {
            if (ModelState.IsValid)
            {
                TB.Create(title);
                return RedirectToAction("Index");
            }

            return View(title);
        }


        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var title = TB.Find((Guid)id);

            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TitleName")] Title title)
        {
            if (ModelState.IsValid)
            {
                TB.Edit(title);
                return RedirectToAction("Index");
            }
            return View(title);
        }

        
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var title = TB.Find((Guid)id);

            if (title == null)
            {
                return HttpNotFound();
            }
            return View(title);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            if (TB.Find(id).Emloyees.Count()>0)
            {
                var errors = "Bu Title da çalışan insanlar olduğu için silinemez";
                return View("_Errors", null, errors);
            }
          
            TB.Delete(id);
            return RedirectToAction("Index");
        }

      
    }
}
