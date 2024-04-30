using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
using Weather_App_GUI.DataAccess;
using Weather_App_GUI.Logic;
using System.Net.Http;
using Serilog;


namespace Weather_App_GUI
{
    public partial class Form1 : Form
    {
        private readonly WeatherService _weatherService;
        private readonly WeatherProcessor _weatherProcessor;

        public Form1()
        {
            Log.Information("Form1 initialized successfully.");
            InitializeComponent();
            HttpClient client = new HttpClient();
            _weatherService = new WeatherService(client);
            _weatherProcessor = new WeatherProcessor();
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            Log.Debug("Fetch weather button clicked.");
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
                Log.Information("Fetching weather data.");
                string weatherInfo = _weatherProcessor.ProcessWeatherData(jsonResponse);
                lblWeather.Text = weatherInfo;
                Log.Information("Weather data fetched successfully.");
            }
            else
            {
                Log.Error("Failed to fetch weather data.");
                MessageBox.Show("Failed to fetch weather data.");
            }

        }

    }

}


