using BlogApp.Areas.Admin.Services;
using BlogApp.Areas.Admin.ViewModels;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly BlogDbContext _context;
        private readonly IFileUploadService fileService;

        public ArticlesController(BlogDbContext _context,IFileUploadService fileService)
        {
            this._context = _context;
            this.fileService = fileService;
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
            var vm = new ArticleAddVM();
            vm.Categories = (from c in _context.Categories
                              select new SelectListItem
                              {
                                  Text = c.CategoryName,
                                  Value = c.Id.ToString(),
                                  Selected = true
                              }).ToList();
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleAddVM addVm, Article article)
        {
            var vm = new ArticleAddVM {
                AuthorName = addVm.AuthorName,
                Title = addVm.Title,
                SlugUri = addVm.SlugUri,
                Body = addVm.Body,
                Views = addVm.Views,
                PublishDate = addVm.PublishDate,
                Picture = addVm.Picture,
                Status = addVm.Status,
            };
            vm.Categories = (from c in _context.Categories
                             select new SelectListItem
                             {
                                 Text = c.CategoryName,
                                 Value = c.Id.ToString(),
                             }).ToList();

            vm.PictureURL = await fileService.UploadFile(vm.Picture);
            vm.CategoryID = addVm.CategoryID;
           
            article = new Article
            {
                Title = vm.Title,
                AuthorName = vm.AuthorName,
                SlugUri = vm.SlugUri,
                Body = vm.Body,
                Views = vm.Views,
                PublishDate = vm.PublishDate,
                PictureURL = vm.PictureURL,
                CategoryID = vm.CategoryID,
                Status = vm.Status,
            };

            _context.Add(article);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                    return View(vm);
        } 
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null || _context.Articles == null)
            {
                return NotFound();
            }
            var articles = await _context.Articles.Include(a=>a.Category).FirstOrDefaultAsync(a=>a.Id == id);
            if (articles == null)
            {
                return NotFound();
            }
            var vm = new ArticleEditVM
            {
                AuthorName = articles.AuthorName,
                Title = articles.Title,
                SlugUri = articles.SlugUri,
                PictureURL = articles.PictureURL,
                Body = articles.Body,
                Id = articles.Id,
                Views = articles.Views,
                PublishDate = articles.PublishDate,
                CategoryID = articles.CategoryID
            };
            vm.Categories = (from c in _context.Categories
                             select new SelectListItem
                             {
                                 Text = c.CategoryName,
                                 Value = c.Id.ToString(),
                                 Selected = articles.CategoryID == c.Id
                             }).ToList();
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticleEditVM vm)
        {
            if(vm.Id != id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {

                    var model=await _context.Articles.Include(a=>a.Category).FirstOrDefaultAsync(a=>a.Id == id);
                    if (vm.Picture.Length > 0)
                    {

                        model.PictureURL = await fileService.UploadFile(vm.Picture);
                    }
                    model.SlugUri = vm.SlugUri;
                    model.Title = vm.Title;
                    model.Views=vm.Views;
                    model.PublishDate = vm.PublishDate;
                    model.AuthorName = vm.AuthorName;
                    model.SlugUri =vm.SlugUri;
                    model.Body = vm.Body;
                    model.CategoryID = vm.CategoryID;
                    model.Id = vm.Id;

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(vm.Id))
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
            return View(vm);
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
        public async Task<IActionResult> Delete(int id)
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
