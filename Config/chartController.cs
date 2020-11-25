using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClaimProject.Config
{
    public class chartController : Controller
    {            
        // GET: chart
        public ActionResult ColumnChart()
        {
            return View();
        } 
    }
}