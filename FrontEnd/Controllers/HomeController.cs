using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult FetchEvents(DateTime start, DateTime end)
        {
            return Json(EventModel.FromEventList(Event.FetchEvents(start, end)), JsonRequestBehavior.AllowGet);
        }
    }
}