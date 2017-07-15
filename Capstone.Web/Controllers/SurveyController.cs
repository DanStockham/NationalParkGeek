using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Linq;
using System.Collections.Generic;
using Capstone.Web.Models;
using Capstone.Web.DAL;


namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        //string connectionString = WebConfigurationManager.ConnectionStrings["NationalParkGeek"].ToString();
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=NationalParkGeek;Integrated Security=True";
        SurveyDAL surveyDal;

        public SurveyController()
        {
            surveyDal = new SurveyDAL(connectionString);
        }

        public ActionResult AddSurvey()
        {
            return View("AddSurvey");
        }

        [HttpPost]
        public ActionResult AddSurvey(Survey survey)
        {
            
            if(!ModelState.IsValid)
            {
                return View("AddSurvey", survey);
            }

            surveyDal.SubmitSurvey(survey);
            return RedirectToAction("TopParks", "Survey");
        }

        public ActionResult TopParks()
        {
            List<string> topParks = surveyDal.GetFavoriteParks();
            return View("TopParks", topParks);
        }
    }
}