using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace Weather_App_GUI.DataAccess
{
    public class WeatherService
    {
        private readonly HttpClient _client;

        public WeatherService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> FetchWeatherData(string zipCode, string apiKey)
        {
            string url = $"https://api.openweathermap.org/data/2.5/forecast?zip={zipCode},us&cnt=3&appid={apiKey}&units=imperial";
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }
        }
    }

}

