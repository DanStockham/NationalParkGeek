using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Web.Models;
using System.Linq;
using System.Web;
using System;

namespace Capstone.Web.DAL
{
    public class WeatherDAL
    {
        private string connectionString;
        private const string SQL_GetWeather = "SELECT * FROM weather w JOIN park p ON w.parkCode = p.parkCode WHERE p.parkCode = @parkCode;";

        public WeatherDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Weather> GetWeather(string parkCode)
        {
            List<Weather> fiveDayForecast = new List<Weather>();

            try
            {   
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetWeather, connection);
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather w = new Weather();

                        w.ParkCode = Convert.ToString(reader["parkCode"]);
                        w.ParkName = Convert.ToString(reader["parkName"]);
                        w.Day = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        w.LowTemp = Convert.ToInt32(reader["low"]);
                        w.HighTemp = Convert.ToInt32(reader["high"]);
                        w.Forecast = Convert.ToString(reader["forecast"]);

                        fiveDayForecast.Add(w);
                    }
                }
            }
            catch
            {
                throw;
            }

            return fiveDayForecast;
        }
    }
}
