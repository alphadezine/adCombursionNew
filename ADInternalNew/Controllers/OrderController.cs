using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ADInternalNew.Models;
using ADInternalNew.DAL;
namespace ADInternalNew.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        AdmisInternalDataContext context = new AdmisInternalDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderSearchAll()
        {
            OrderSearch ObjOrderSerach = new OrderSearch();
            ObjOrderSerach.listcompany =(from c in context.Users
                                         join d in context.User_To_Role_Mappings on c.User_Id equals d.User_Id
                                             where d.User_Id == Convert.ToInt32(1)
                                             select c).ToList();
            ObjOrderSerach.listorderstatus =(from o in context.Order_Status select o).ToList();
            ObjOrderSerach.listordertype = (from t in context.Order_Types select t).ToList();
            ObjOrderSerach.listuser = (from c in context.Users
                                        join d in context.User_To_Role_Mappings on c.User_Id equals d.User_Id
                                        where d.User_Id == Convert.ToInt32(2)
                                        select c).ToList();
            return View(ObjOrderSerach);
        }
    }
}
