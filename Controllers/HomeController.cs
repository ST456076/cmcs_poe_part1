using System.Diagnostics;
using cmcs_poe_part1.Models;
using Microsoft.AspNetCore.Mvc;

namespace cmcs_poe_part1.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
         
        //action method for register page
        public IActionResult register()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Claims()
        {
            return View();
        }
        public IActionResult ClaimReport()
        {
            return View();
        }
        public IActionResult trackclaims()
        {
            return View();
        }  public IActionResult finalClaimApproval()
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
