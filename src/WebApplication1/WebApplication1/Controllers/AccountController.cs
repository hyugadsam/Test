using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                var proxy = Proxy.ProxyUtil.GetProxy();
                var result = proxy.isValid(model.UserLogin, model.Password);

                if (result != null && result.UserInfo != null && result.isSaved)
                {
                    if (!result.UserInfo.isActive)
                    {
                        TempData["LoginError"] = true;
                        TempData["Message"] = "Usuario Inactivo";
                        return View();
                    }

                    var cookie = new HttpCookie("Roleid", result.UserInfo.Roleid.ToString());
                    var cookie2 = new HttpCookie("Userid", result.UserInfo.Userid.ToString());
                    Response.AppendCookie(cookie);
                    Response.AppendCookie(cookie2);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["LoginError"] = true;
                    TempData["Message"] = "Las credenciales son incorrectas, favor de verificarlas";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["LoginError"] = true;
                TempData["Message"] = ex.Message;
                return View();
            }
            
        }

    }
}