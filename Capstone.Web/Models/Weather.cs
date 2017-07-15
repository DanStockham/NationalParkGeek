using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Weather
    {

        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public int Day { get; set; }
        public int LowTemp { get; set; }
        public int HighTemp { get; set; }
        public string Forecast { get; set; }
        public string ImgName { get; set; }

        public Dictionary<string, string> Advisory { get; } = new Dictionary<string, string>()
        {
            {"rain", "You may regret not wearing waterproof shoes or forgetting your umbrella..."},
            {"sun", "Skip the sunburn: remember to apply sunblock liberally."},
            {"snow", @"Don't forget to pack snowshoes!"},
            {"thunderstorms", "In case of storms, seek shelter and avoid hiking on exposed ridges."},
            {"hot","HIGH HEAT ADVISORY - Bring extra water!"},
            {"cold","COLD WEATHER ADVISORY - Wear layers!"},
            {"variable","Variable temperatures - Wear breathable layers for comfort throughout the day!"}
        };

        public string PrintAdvisory(Dictionary<string, string> forecast)
        {
            string advisory = "";

            if(Forecast == "snow")
            {

                advisory = forecast["snow"];
            }
            else if(Forecast == "rain")
            {
                advisory = forecast["rain"];
            }
            else if(Forecast == "sun")
            {
                advisory = forecast["sun"];
            }
            else if(Forecast == "thunderstorms")
            {
                advisory = forecast["thunderstorms"];
            }
            else if(HighTemp - LowTemp > 20)
            {
                advisory = forecast["variable"];
            }
            else if(HighTemp > 75 || LowTemp > 75)
            {
                advisory = forecast["hot"];
            }
            else if(HighTemp < 20 || LowTemp < 20)
            {
                advisory = forecast["cold"];
            }
            
           
            return advisory;
        }

        public string WeatherImg(string dailyForecast)
        {
            if (dailyForecast == "rain")
            {
                ImgName = "rain.png";
            }
            else if (dailyForecast == "cloudy")
            {
                ImgName = "cloudy.png";
            }
            else if (dailyForecast == "partly cloudy")
            {
                ImgName = "partlyCloudy.png";
            }
            else if (dailyForecast == "snow")
            {
                ImgName = "snow.png";
            }
            else if (dailyForecast == "sunny")
            {
                ImgName = "sunny.png";
            }
            else if (dailyForecast == "thunderstorms")
            {
                ImgName = "thunderstorms.png";
            }

            return ImgName;
        }

        public double ToCelcius(int tempF)
        {
           
            return Math.Round(((tempF - 32) * (5.00 / 9.00)), 2);
 
        }

        public int ToFahrenheit(double tempC)
        {
         
            return (int)Math.Round(tempC * 9 / 5 + 32);
        }
    }
}
