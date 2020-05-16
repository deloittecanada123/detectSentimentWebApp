using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using detectSentimentWebApp.Models;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using static detectSentimentWebApp.Models.detectSentiment;

namespace detectSentimentWebApp.Controllers
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
            string endpoint = "https://detectsentimentaris.cognitiveservices.azure.com/"; // insert your endpoint
            string key = "aba934b96e4c4f058d93add4a1182a88"; // insert your keyy

            var credentials = new ApiKeyServiceClientCredentials(key);
            var client = new TextAnalyticsClient(credentials)
            {
                Endpoint = endpoint
            };

            var result = client.Sentiment("I had the best day of my life.", "en");

            ViewBag.Score = result.Score;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
