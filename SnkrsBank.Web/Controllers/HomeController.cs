namespace SnkrsBank.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using RestSharp;
    using SnkrsBank.Web.Models;
    using SnkrsBank.Web.ViewModels;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var client = new RestClient("https://api.predicthq.com/v1/events/");
            client.AddDefaultHeader("Authorization", "Bearer ZN79Mw9lMMWGgNMDSA3NwO5MpoczZI");
            client.AddDefaultHeader("Accept", "application/json");
            var restRequest = new RestRequest();
            restRequest.AddQueryParameter("category", "events");
            restRequest.AddQueryParameter("label", "movie");
            restRequest.AddQueryParameter("q", "film");
            restRequest.AddQueryParameter("offset", "4");
            var response = client.Get(restRequest);
            var sneakerEvenetList = new List<SneakerEvent>();

            try
            {
                if (response.IsSuccessful)
                {
                    var results = JsonConvert.DeserializeObject<SneakerEventResult>(response.Content);
                    sneakerEvenetList = results.Results;
                }
            }
            catch
            {
            }

            return this.View(sneakerEvenetList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
