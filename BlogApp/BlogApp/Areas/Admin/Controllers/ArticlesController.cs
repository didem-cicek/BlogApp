using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly BlogDbContext _context;
        public ArticlesController(BlogDbContext _context)
        {
            this._context = _context;
        }
        public async Task<IActionResult> Index() {
            return _context.Articles != null ?
                View(await _context.Articles.ToListAsync()) :
                Problem("Makale bulunamadı!");
        }
        public async Task<IActionResult> Detail(int? id) {
            if(id== null || _context.Articles == null)
            {
                return NotFound();
            }
            var articles = await _context.Articles
                .FirstOrDefaultAsync(a=>a.Id == id);
            if(articles == null)
            {
                return NotFound();
            }
            return View(articles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title, Author, PictureURL, Views, CategoryName, PublishedDate, SlugUri, Id")] Article articles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articles);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null || _context.Articles == null)
            {
                return NotFound();
            }
            var articles = _context.Articles.FindAsync(id);
            if (articles == null)
            {
                return NotFound();
            }
            return View(articles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind ("Title, Author, PictureURL, Views, CategoryName, PublishedDate, SlugUri, Id")] Article articles)
        {
            if(articles.Id != id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articles);
                    await _context.SaveChangesAsync();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(articles.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(articles);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id==null || _context.Articles == null)
            {
                return NotFound();
            }
            var articles = await _context.Articles.FirstOrDefaultAsync(a=>a.Id == id);
            if(articles == null)
            {
                return NotFound();
            }
            return View(articles);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Articles == null)
            {
                return Problem("Makale Bulunamadı!");
            }
            var articles = await _context.Articles.FindAsync(id);
            if(articles != null)
            {
                _context.Articles.Remove(articles);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ArticleExists(int id)
        {
            return (_context.Articles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
