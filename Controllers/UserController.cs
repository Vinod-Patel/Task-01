using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult UserDashboard()
        {
            var userId = Convert.ToInt32(TempData["UserId"]);
            var categories = _context.UserCategories.Where(uc => uc.UserId == userId)
                                                      .Select(uc => uc.CategoryId)
                                                      .ToList();
            return View(categories);
        }
    }
}
