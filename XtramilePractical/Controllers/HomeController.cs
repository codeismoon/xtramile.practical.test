using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using XtramilePractical.Models;

namespace XtramilePractical.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> countries = new List<string>();

            string apiUrl = "https://localhost:5001/api/location/country";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Get, apiUrl);

                    HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                    string result = string.Empty;
                    using (var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        result = reader.ReadToEnd();
                    };

                    _logger.LogDebug($"Api Result : {result}");
                    Console.WriteLine($"Api Result CW : {result}");

                    countries = JsonConvert.DeserializeObject<List<string>>(result);
                }
                catch (HttpRequestException e)
                {
                    _logger.LogDebug($"Request Error: {e.Message}");
                }
            }

            ViewData["Countries"] = countries;
            return View();
        }

        public JsonResult GetCities(string country)
        {
            List<string> cities = new List<string>();

            string apiUrl = "https://localhost:5001/api/location/city?country=" + country;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Get, apiUrl);

                    HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                    string result = string.Empty;
                    using (var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        result = reader.ReadToEnd();
                    };

                    _logger.LogDebug($"Api Result : {result}");
                    Console.WriteLine($"Api Result CW : {result}");

                    cities = JsonConvert.DeserializeObject<List<string>>(result);
                }
                catch (HttpRequestException e)
                {
                    _logger.LogDebug($"Request Error: {e.Message}");
                }
            }

            return Json(cities);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
