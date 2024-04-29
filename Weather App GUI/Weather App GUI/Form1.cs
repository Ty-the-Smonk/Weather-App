using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
using Weather_App_GUI.DataAccess;
using Weather_App_GUI.Logic;
using System.Net.Http;

namespace Weather_App_GUI
{
    public partial class Form1 : Form
    {
        private readonly WeatherService _weatherService;
        private readonly WeatherProcessor _weatherProcessor;

        public Form1()
        {
            InitializeComponent();
            HttpClient client = new HttpClient();
            _weatherService = new WeatherService(client);
            _weatherProcessor = new WeatherProcessor();
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            string apiKey = ApiKeyConfig.OpenWeatherApiKey;
            string zipCode = "19508";  // This could be dynamically set from a user input for more flexibility
            if (String.IsNullOrEmpty(apiKey))
            {
                MessageBox.Show("API Key is not set in environment variables.");
                return;
            }

            string jsonResponse = await _weatherService.FetchWeatherData(zipCode, apiKey);
            if (jsonResponse != null)
            {
                string weatherInfo = _weatherProcessor.ProcessWeatherData(jsonResponse);
                lblWeather.Text = weatherInfo;
            }
            else
            {
                MessageBox.Show("Failed to fetch weather data.");
            }
        }
    }

}


