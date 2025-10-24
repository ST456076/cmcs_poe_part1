using System.Diagnostics;
using cmcs_poe_part1.Models;
using cmcs_poe_part1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cmcs_poe_part1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;  

        
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Home page visited.");
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
        [HttpGet]
        public IActionResult trackclaims()
        {
            var claims = _context.Claims.ToList();
            return View(claims);
        }
        [HttpPost]
        public IActionResult trackclaims(Claim claim, IFormFile documents)
        {
            if (documents != null && documents.Length > 0)
            {
                claim.SupportingDocuments = documents.FileName;
            }
            else
            {
                claim.SupportingDocuments = "No document uploaded";
            }

            _context.Claims.Add(claim);
            _context.SaveChanges();
            return RedirectToAction("TrackClaims");
        }
        public IActionResult finalClaimApproval()
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
