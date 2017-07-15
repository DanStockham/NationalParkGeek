using System.Collections.Generic;
using System.Web.Configuration;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System;


namespace Capstone.Web.Controllers
{
    public class ParkController : Controller
    {
        public ActionResult ParkDetail(Park model)
        {
            return View("ParkDetail", model);
        }
    }
}