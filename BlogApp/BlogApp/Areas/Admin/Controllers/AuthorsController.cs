using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AuthorsController : Controller
    {
        private readonly BlogDbContext _context;
        public AuthorsController(BlogDbContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index() => View();
        public async Task<IActionResult> List()
        {
            return _context.Articles != null ?
            View(await _context.Articles.ToListAsync()) :
            Problem("Yazar bulunamadı!");
        }
        public IActionResult Detail() => View();
    }
}
