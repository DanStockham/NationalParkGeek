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
    public class ParkDALTests
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=NationalParkGeek;Integrated Security=True";
        private int parkCount = 0;


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

                cmd = new SqlCommand("SELECT COUNT(*) FROM park;", connection);
                parkCount = (int)cmd.ExecuteScalar();
            }

        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetAllParksTest()
        {
            ParkDAL parkDal = new ParkDAL(connectionString);
            List<Park> parks = parkDal.GetAllParks();

            Assert.IsNotNull(parks);
            Assert.AreEqual(parkCount, parks.Count);

        }

        [TestMethod]
        public void GetParkDetailTest()
        {
            ParkDAL parkDal = new ParkDAL(connectionString);

            Park park = parkDal.GetParkDetail("ABCD");
            Assert.IsNotNull(park);
            Assert.AreEqual("ABCD", park.ParkCode);
            Assert.AreEqual("Ohio", park.State);
        }
    }
}
