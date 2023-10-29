using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using XtramilePractical.Models;
using XtramilePractical.Services;
using XtramilePractical.Utilities;

namespace XtramilePractical.APIControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly ITemperatureConverter _temperatureConverter;

        public LocationController(ILocationService locationService, ITemperatureConverter temperatureConverter)
        {
            _locationService = locationService;
            _temperatureConverter = temperatureConverter;
        }

        [HttpGet("country")]
        public ActionResult<IEnumerable<LocationModel>> GetAllCountries()
        {
            var locations = _locationService.GetAllCountry();
            return Ok(locations.Select(x => x.Country).Distinct().ToList());
        }

        [HttpGet("city")]
        public ActionResult<IEnumerable<LocationModel>> GetAllCities(string country)
        {
            var locations = _locationService.GetAllCountry();
            return Ok(locations.Where(co => co.Country.ToLower().Equals(country.ToLower())).Select(ci => ci.City).ToList());
        }

        [HttpGet("weather")]
        public ActionResult<WeatherRequestModel> GetWeather(string city)
        {
            //string secretKey = "4ac8a03bca9acb2ca65284d4b2e5e300";
            //string apiUrl = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + secretKey;
            //string result = string.Empty;

            //using (HttpClient client = new HttpClient())
            //{
            //    try
            //    {
            //        var requestMessage = new HttpRequestMessage(HttpMethod.Get, apiUrl);

            //        HttpResponseMessage response = client.SendAsync(requestMessage).Result;

            //        using (var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
            //        {
            //            result = reader.ReadToEnd();
            //        };

            //        Console.WriteLine($"Api Result CW : {result}");

            //    }
            //    catch (HttpRequestException e)
            //    {
            //        return BadRequest(e.Message);
            //    }
            //}

            string result = "{\"location\":\"Bandung\",\"time\":\"12:12:12 AM\",\"wind\":\"4.1\",\"visibility\":\"10000\",\"skycondition\":\"Drizzle\",\"temperature\":\"80.32\",\"dewpoint\":\"5\",\"relativehumidity\":\"81\",\"pressure\":\"1012\"}";
            var weather = JsonConvert.DeserializeObject<WeatherResponseModel>(result);

            weather.TemperatureCelsius = _temperatureConverter.FahrenheitToCelsius(Convert.ToDouble(weather.TemperatureFahrenheit)).ToString();
            return Ok(weather);
        }
    }
}
