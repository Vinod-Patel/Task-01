using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult ManageUsers()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public ActionResult ManageCategories()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpPost]
        public ActionResult AddUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("ManageUsers");
        }

        [HttpPost]
        public ActionResult EditUser(int id, Users user)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Phone = user.Phone;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.IsAdmin = user.IsAdmin;
                _context.SaveChanges();
            }
            return RedirectToAction("ManageUsers");
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("ManageUsers");
        }
    }
}
