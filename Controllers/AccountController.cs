using cmcs_poe_part1.Models;
using Microsoft.AspNetCore.Mvc;

namespace cmcs_poe_part1.Controllers
{
    public class AccountController : Controller
    {
        private object object1;
        private object object2;

        public AccountController(object object1, object object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // TO DO: Implement registration logic here
            // For now, just redirect to login page
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // TO DO: Implement login logic here
            // For now, just redirect to home page
            return RedirectToAction("Index", "Home");
        }
    }
}