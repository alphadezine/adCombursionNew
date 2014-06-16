using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADInternalNew.Models;
using ADInternalNew.DAL;
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

        public JsonResult ClientList(string term)
        {
            ClientModel cm = new ClientModel();
            return Json(cm.GetClients(term).Select(x=>new {x.User_Id,name=x.First_Name+" "+x.Last_Name}), JsonRequestBehavior.AllowGet);
        }


    }
}
