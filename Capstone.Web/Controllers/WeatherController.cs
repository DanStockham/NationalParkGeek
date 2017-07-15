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
    public class WeatherController : Controller
    {
        //string connectionString = WebConfigurationManager.ConnectionStrings["NationalParkGeek"].ToString();
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=NationalParkGeek;Integrated Security=True";
        WeatherDAL weatherDal;

        public WeatherController()
        {
            weatherDal = new WeatherDAL(connectionString);
        }

        //public ActionResult Forecast(string parkCode)
        //{
        //    List<Weather> forecast = weatherDal.GetWeather(parkCode);

        //    return View("Forecast", forecast);
        //}

        public ActionResult Forecast(Park park)
        {
            if(Session["tempType"] == null)
            {
                Session["tempType"] = "F";
            }

            List<Weather> forecast = weatherDal.GetWeather(park.ParkCode);

            return View("Forecast", forecast);
        }

        public ActionResult Convert(string parkCode)
        {
            //List<Weather> forecast = weatherDal.GetWeather(parkCode);

            if ((string) Session["tempType"] == "F")
            {
                Session["tempType"] = "C";
                return RedirectToAction("Forecast", "Weather", new { parkCode = parkCode });
            } 
            else
            {
                Session["tempType"] = "F";
                return RedirectToAction("Forecast", "Weather", new { parkCode = parkCode });
            }
        }
    }
}