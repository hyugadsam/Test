using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ServiceReference;

namespace WebApplication1.Controllers
{
    public class FinanceController : Controller
    {
        // GET: Finance
        public ActionResult Index()
        {
            var proxy = Proxy.ProxyUtil.GetProxy();
            var response = proxy.GetPaySheets(null);
            TempData["IsFull"] = true;
            if (response != null && response.isSaved && response.paySheets != null)
            {
                return View(response.paySheets);
            }
            else
            {
                return View(new List<PaySheet>());
            }
        }

        // GET: Finance by Id
        public ActionResult IndexById()
        {
            var proxy = Proxy.ProxyUtil.GetProxy();
            var cookie = Request.Cookies["Userid"];
            var response = proxy.GetPaySheets(Convert.ToInt32(cookie.Value));
            if (response != null && response.isSaved && response.paySheets != null)
            {
                return View("Index", response.paySheets);
            }
            else
            {
                return View("Index", new List<PaySheet>());
            }
        }



        // GET: Finance/Details/
        public ActionResult Details(int id)
        {
            var proxy = Proxy.ProxyUtil.GetProxy();
            var response = proxy.GetPaySheetById(id);
            if (response != null && response.isSaved && response.paySheets != null)
            {
                return View(response.paySheets.FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Create()
        {
            return View(new DateModel {Date = DateTime.Now });
        }

        [HttpPost]
        public ActionResult Create(DateModel Fecha)
        {
            var proxy = Proxy.ProxyUtil.GetProxy();
            var response = proxy.GeneratePaysheets(Fecha.Date);
            return RedirectToAction("Index", "Finance");
        }


    }
}
