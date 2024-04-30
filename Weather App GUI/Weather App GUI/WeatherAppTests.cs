using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using Weather_App_GUI.DataAccess;
using System.Net;
using System;
using NUnit.Framework.Legacy;
namespace Weather_App_GUI
{
    [TestFixture]
    public class WeatherAppTests
    {
        private Mock<HttpClient> _mockHttpClient;
        private WeatherService _weatherService;

        [SetUp]
        public void Setup()
        {
            _mockHttpClient = new Mock<HttpClient>();
            _weatherService = new WeatherService(_mockHttpClient.Object);
        }

        [Test]
        public async Task GetWeather_ValidZip_ReturnsWeather()
        {
            // Arrange
            var validZip = "90210";
            var expectedResponse = "{...}"; // JSON response expected from API
            _mockHttpClient.Setup(client => client.GetAsync(It.IsAny<string>()))
                           .ReturnsAsync(new HttpResponseMessage
                           {
                               StatusCode = HttpStatusCode.OK,
                               Content = new StringContent(expectedResponse)
                           });

            // Act
            var result = await _weatherService.FetchWeatherData(validZip, "api_key");

            // Assert
            
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(expectedResponse, result);
        }

        [Test]
        public async Task GetWeather_InvalidZip_ReturnsNull()
        {
            // Arrange
            var invalidZip = "00000";
            _mockHttpClient.Setup(client => client.GetAsync(It.IsAny<string>()))
                           .ReturnsAsync(new HttpResponseMessage
                           {
                               StatusCode = HttpStatusCode.BadRequest
                           });

            // Act
            var result = await _weatherService.FetchWeatherData(invalidZip, "api_key");

            // Assert
            ClassicAssert.IsNull(result);
        }

    }
}
