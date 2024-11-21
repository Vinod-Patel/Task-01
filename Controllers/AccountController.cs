using System.Web;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                // Pass user details through TempData for one-time use
                TempData["UserId"] = user.Id;
                TempData["IsAdmin"] = user.IsAdmin;

                // Redirect to respective dashboards
                return RedirectToAction(user.IsAdmin ? "Dashboard" : "UserDashboard", "Admin");
            }

            // Return the same view if login fails
            ViewBag.ErrorMessage = "Invalid email or password.";
            return View();
        }

        public ActionResult Logout()
        {
            TempData.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}
