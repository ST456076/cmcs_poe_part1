using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace cmcs_poe_part1.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }
    }

    public class AccountController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if email contains "@" symbol
                if (!model.Email.Contains("@"))
                {
                    ModelState.AddModelError("Email", "Invalid email address");
                    return View(model);
                }

                // Check password strength
                if (!IsPasswordStrong(model.Password))
                {
                    ModelState.AddModelError("Password", "Password is not strong enough");
                    return View(model);
                }

                // Login logic here
            }

            return View(model);
        }

        private bool IsPasswordStrong(string password)
        {
            // Check if password contains at least one uppercase letter, one lowercase letter, and one digit
            return password.Any(c => char.IsUpper(c)) &&
                   password.Any(c => char.IsLower(c)) &&
                   password.Any(c => char.IsDigit(c));
        }
    }
}