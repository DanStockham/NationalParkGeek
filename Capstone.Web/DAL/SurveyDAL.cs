using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Web.Models;
using System.Linq;
using System.Web;
using System;

namespace Capstone.Web.DAL
{
    public class SurveyDAL
    {
        private string connectionString;
        private const string SQL_TopParks = "SELECT p.parkName, sr.parkCode, COUNT(sr.parkCode) AS numOfSurveys FROM survey_result sr JOIN park p ON p.parkCode = sr.parkCode GROUP BY sr.parkCode, p.parkName ORDER BY numOfSurveys DESC, p.parkName ASC;";
        private const string SQL_SubmitSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";

        public SurveyDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<string> GetFavoriteParks()
        {
            List<string> topParks = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_TopParks, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Survey s = new Survey();

                        s.ParkName = Convert.ToString(reader["parkName"]);
                        s.SurveyCount = Convert.ToInt32(reader["numOfSurveys"]);
                        s.ParkCode = Convert.ToString(reader["parkCode"]);

                        topParks.Add(s.ParkCode + "," + s.ParkName  + "," + s.SurveyCount);
                    }
                }
            }
            catch
            {
                throw;
            }

            return topParks;
        }

        public bool SubmitSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SubmitSurvey, connection);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch(SqlException e)
            {
                throw e;
            }
        }
    }
}