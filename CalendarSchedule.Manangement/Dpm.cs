using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Events.Month;

namespace DayPilotMonthLiteMvc4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Backend()
        {
            return new Dpm().CallBack(this);
        }

        class Dpm : DayPilotMonth
        {

            protected override void OnInit(InitArgs e)
            {
                var db = new DataClasses1DataContext();
                Events = from ev in db.events select ev;

                DataIdField = "id";
                DataTextField = "text";
                DataStartField = "eventstart";
                DataEndField = "eventend";

                Update();
            }
        }
    }
}
