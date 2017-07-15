using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Capstone.Web.Tests.Controllers
{
    [TestClass]
    public class SurveyControllerTest
    {
        [TestMethod()]
        public void AddSurvey_HttpGet_ReturnsCorrectView()
        {
            //Arrange
            SurveyController controller = new SurveyController();

            //Act
            ViewResult result = controller.AddSurvey() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("AddSurvey", result.ViewName);
        }

        [TestMethod()]
        public void TopParks_HttpGet_ReturnsCorrectView()
        {
            //Arrange
            SurveyController controller = new SurveyController();

            //Act
            ViewResult result = controller.TopParks() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("TopParks", result.ViewName);
        }        
    }
}
