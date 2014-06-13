using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADInternalNew.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClientDashboard()
        {
            return View();
        }

        public ActionResult Notifications()
        {
            return View();
        }

        public ActionResult InProgress()
        {
            return View();
        }

        public ActionResult Completed()
        {
            return View();
        }

        public ActionResult DueAmt()
        {
            return View();
        }



    }
}
