using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using XYZContacts.BusinessLogicLayer;
using XYZContacts.Entities;
using XYZContacts.WebUI.Models;

namespace XYZContacts.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private AppIdentityBusiness AIB = new AppIdentityBusiness();

        [AllowAnonymous]
        public ActionResult Index()
        {

            var identity = AIB.First(User.Identity.Name);

            var model = new AccountModel();
            model.Username = identity.Username;
            model.Password = identity.Password;
            model.RePassword = identity.Password;

            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                var identity = AIB.First(User.Identity.Name);
                identity.Username = model.Username;
                identity.Password = model.Password;

                AIB.Edit(identity);

                return Redirect("/Employee");
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("_Errors",null, "Yetkiniz bu durum için yeterli değildir !");
            }

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var identity = AIB.First(model.Username,model.Password); 

                if (identity!=null )
                {
                    if (identity.IdentityState == IdentityState.Active)
                    {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.SetAuthCookie(model.Username, false);

                        return Redirect("/Employee/Index");
                    }

                    else
                    {
                        ModelState.AddModelError("IdentityStateErrors","Hesabınızın " + identity.IdentityState+ " edilmiştir." );
                    }
                   
                }

                else
                {
                    ModelState.AddModelError("LoginModelErrors", "Kullanıcı Adı veya Şifre yanlış !");
                    return View(model);
                }
            }

            return View(model);
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}