using Microsoft.AspNetCore.Mvc;

namespace BookReviewApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
