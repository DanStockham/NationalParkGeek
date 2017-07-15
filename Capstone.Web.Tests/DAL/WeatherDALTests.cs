using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Tests.DAL
{
    [TestClass]
    public class WeatherDALTests
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=NationalParkGeek;Integrated Security=True";
        private int forecastCount = 0;
        

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                connection.Open();
                cmd = new SqlCommand("INSERT INTO park VALUES('ABCD','TestPark', 'Ohio', 1000, 1000, 1000, 1000, 'Artic', 2017, 0, 'Go us', 'bob', 'groovy', 10, 200)", connection);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO weather VALUES('ABCD', 1, 38, 96, 'tornados');", connection);
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("SELECT COUNT(*) FROM weather w JOIN park p ON w.parkCode = p.parkCode WHERE p.parkCode = 'ABCD';", connection);
                forecastCount = (int)cmd.ExecuteScalar();
            }

        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetWeatherTest()
        {
            WeatherDAL dal = new WeatherDAL(connectionString);
            List<Weather> forecast = dal.GetWeather("ABCD");

            Assert.IsNotNull(forecast);
            Assert.AreEqual(forecastCount, forecast.Count);
        }
    }
}
