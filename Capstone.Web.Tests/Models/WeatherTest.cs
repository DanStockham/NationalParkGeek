using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Capstone.Web.Models;

namespace Capstone.Web.Tests.Models
{
    [TestClass]
    public class WeatherTest
    {
        [TestMethod]
        public void ToCelciusTest()
        {
            Weather temp = new Weather();
            Assert.AreEqual(100, temp.ToCelcius(212));

            temp = new Weather();
            Assert.AreEqual(0, temp.ToCelcius(32));
        }

        [TestMethod]
        public void ToFahrenheitTest()
        {
            Weather temp = new Weather();
            Assert.AreEqual(212, temp.ToFahrenheit(100));

            temp = new Weather();
            Assert.AreEqual(32, temp.ToFahrenheit(0));
        }
    }
}
