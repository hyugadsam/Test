using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ServiceReference;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var proxy = Proxy.ProxyUtil.GetProxy();
            var response = proxy.GetUsers();
            if (response != null && response.isSaved)
            {
                return View(response.Users);
            }
            else
            {
                return View(new List<User>());
            }
        }

        // GET: Users/Details/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return View(new User { InsertDate = DateTime.Now, Userid = 0 });
            }
            var proxy = Proxy.ProxyUtil.GetProxy();
            var response = proxy.GetUsers();
            if (response != null && response.isSaved && response.Users.Where(r => r.Userid == id).Any())
            {
                return View(response.Users.Where(r => r.Userid == id).First());
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User collection)
        {
            try
            {
                // TODO: Add update logic here
                var proxy = Proxy.ProxyUtil.GetProxy();
                var response = proxy.SaveUser(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

    }
}
