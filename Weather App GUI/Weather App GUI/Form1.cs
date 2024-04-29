using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Weather_App_GUI
{
    public partial class Form1 : Form
    {
        static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private  void btnGet_Click(object sender, EventArgs e)
        {
            Main();
            
        }

        private void Main()
        {
            string apiKey = "dfe51a7fb46eedc051a9fbbce46cff78";
            string zipCode = "19508";

            string url = $"https://api.openweathermap.org/data/2.5/forecast?zip={zipCode}," + "us" + $"&cnt=3&appid={apiKey}&units=imperial";
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result; 
                ParseAndDisplayWeather(responseBody);
            }
            else
            {
                MessageBox.Show("Error fetching weather data.");
            }
        }

        private void ParseAndDisplayWeather(string jsonString)
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

            lblWeather.Text = weatherInfo;
            }
        }
    }


