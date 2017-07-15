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
    public class HomeController : Controller
    {
        //string connectionString = WebConfigurationManager.ConnectionStrings["NationalParkGeek"].ToString();  When we use webconfig address controller tests do not work but hard string does work.
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=NationalParkGeek;Integrated Security=True";
        ParkDAL parkDal;

        public HomeController()
        {
            parkDal = new ParkDAL(connectionString);
        }

        // GET: Home
        public ActionResult Index()
        {
            List<Park> nationalParks = parkDal.GetAllParks();

            return View("Index", nationalParks);
        }
    }
}