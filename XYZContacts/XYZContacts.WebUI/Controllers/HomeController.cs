using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XYZContacts.BusinessLogicLayer;

namespace XYZContacts.WebUI.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private EmployeeBusiness EB = new EmployeeBusiness();
    
        public ActionResult Index()
        {
            
            
            return View(EB.GetAll().ToList());
        }

        public ActionResult Details(Guid id)
        {
            
            return View(EB.Find(id));
        }
    }
}