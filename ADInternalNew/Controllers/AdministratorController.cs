﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADInternalNew.Controllers
{
    public class AdministratorController : Controller
    {
        //
        // GET: /Administrator/

       
         public ActionResult Index()
        {
            return View();
        }

         public ActionResult Skill()
         {
             return View();
         }

         public ActionResult Order_Status()
         {
             return View();
         }


    }
}
