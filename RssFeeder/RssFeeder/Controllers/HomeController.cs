using Microsoft.AspNetCore.Mvc;
using RssFeeder.Models;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Web;
using RssFeeder.Models.Common;
namespace RssFeeder.Controllers
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
            try
            {
                ConnectionManager? connectionManager = ConnectionManager.XmlDesirializer("config1.xml");
                this.HttpContext.Response.Headers.Add("refresh", $"{connectionManager.UpdateTime}; url=" + Url.Action("Index"));
                return View(RssReader.GetRssFeed(connectionManager));
            }
            catch (Exception ex)
            {
                return View("Exception", ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}