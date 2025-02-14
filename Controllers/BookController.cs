using Microsoft.AspNetCore.Mvc;
using BookReviewApp.Data;
using BookReviewApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookReviewApp.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Book/Index
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.Include(b => b.Reviews).ToListAsync();
            return View(books);
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await _context.Books.Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/AddReview/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(int bookId, Review review)
        {
            if (ModelState.IsValid)
            {
                review.BookId = bookId;
                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                var book = await _context.Books.Include(b => b.Reviews)
                    .FirstOrDefaultAsync(b => b.Id == bookId);

                if (book != null)
                {
                    book.AverageRating = (decimal)book.Reviews.Average(r => r.Rating);
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Details), new { id = bookId });
            }
            return View(review);
        }
    }
}
