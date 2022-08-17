using BlogApp.Areas.Admin.ViewModels;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class AdminBlogListViewComponent : ViewComponent
    {
            private readonly BlogDbContext _context;
            public AdminBlogListViewComponent(BlogDbContext _context)
            {
                this._context = _context;
            }
            public async Task<IViewComponentResult> InvokeAsync(string categoryName = null)
            {
                var model = new List<AdminBlogListViewModels>();
                if (categoryName == null)
                {
                    model = await (from q in _context.Articles.Include(c => c.Category)
                                   select new AdminBlogListViewModels
                                   {
                                       Id = q.Id,
                                       Title = q.Title,
                                       Author = q.AuthorName,
                                       PictureURL = q.PictureURL,
                                       Views = q.Views,
                                       CategoryName = q.Category.CategoryName,
                                       PublishedDate = q.PublishDate,
                                       SlugUri = q.SlugUri,
                                   }
                                   ).Take(10).ToListAsync();

                }
                return View(model);
            }
        }
    }
