using CMS.Perestation.Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CMS.Perestation.Layer.Areas.Home.Controllers
{
    [Area(nameof(Home))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult defalut()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Auth()
        {
            return View();
        }
        public IActionResult Pharmacy()
        {
            return View();
        }
        public IActionResult Lab()
        {
            return View();
        }
        public IActionResult Dentist()
        {
            return View();
        }
        public IActionResult Radiologist()
        {
            return View();
        }
        public IActionResult Dentiphysiotherapist()
        {
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
