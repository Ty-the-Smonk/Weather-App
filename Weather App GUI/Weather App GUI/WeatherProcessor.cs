using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App_GUI.Logic
{
    public class WeatherProcessor
    {
        public string ProcessWeatherData(string jsonString)
        {
            JObject weatherData = JObject.Parse(jsonString);
            JArray forecastList = (JArray)weatherData["list"];

            string weatherInfo = "";
            int dayCounter = 1;
            foreach (JObject forecast in forecastList)
            {
                JArray weatherDetails = (JArray)forecast["weather"];
                foreach (JObject weather in weatherDetails)
                {
                    string main = weather["main"].ToString();
                    string description = weather["description"].ToString();
                    weatherInfo += $"Weather is {main}\n";
                }

                JObject mainDetails = (JObject)forecast["main"];
                string tempMin = mainDetails["temp_min"].ToString();
                weatherInfo += $"With a low of {tempMin}F for day {dayCounter}\n";
                dayCounter++;
            }

            return weatherInfo;
        }

    }
}
