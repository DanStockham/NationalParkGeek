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
    public class SurveyDALTests
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=NationalParkGeek;Integrated Security=True";
        private int topParksCount = 0;


        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                connection.Open();
                cmd = new SqlCommand("  SELECT COUNT(*) FROM (SELECT parkCode FROM survey_result Group By parkCode) AS NumberTopParks;", connection);
                topParksCount = (int)cmd.ExecuteScalar();

            }

        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void TopParksTests()
        {
            SurveyDAL dal = new SurveyDAL(connectionString);


            List<string> s = dal.GetFavoriteParks();

            Assert.IsNotNull(s);
            Assert.AreEqual(topParksCount, s.Count);
        }

        [TestMethod]
        public void SubmitSurveyTests()
        {
            SurveyDAL dal = new SurveyDAL(connectionString);

            Survey s = new Survey
            {
                ParkCode = "YNP",
                Email = "test@test.com",
                State = "Ohio",
                ActivityLevel = "Sedentary",

            };

            bool newSurvey = dal.SubmitSurvey(s);

            Assert.AreEqual(true, newSurvey);


        }
    }
}
