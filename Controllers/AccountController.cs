using Microsoft.AspNetCore.Mvc;
using BookReviewApp.Data;
using BookReviewApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookReviewApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User loginUser)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users
                    .FirstOrDefault(u => u.Username == loginUser.Username && u.Password == loginUser.Password);

                if (user != null)
                {
                    // Logic to store session or cookie data here
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View(loginUser);
        }

        // You can add additional actions like Logout, etc.
    }
}