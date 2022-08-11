using BlogApp.Models;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class TrimbleCarouselBlogViewComponent : ViewComponent
    {
        private readonly BlogDbContext context;

        public TrimbleCarouselBlogViewComponent (BlogDbContext context) { this.context = context; }

        public async Task<IViewComponentResult> InvokeAsync(string categoryName)
        {
            var model = await (from q in context.Articles.Include(c => c.Category)
                               where q.Category.CategoryName == categoryName
                               select new TrimbleCarouselBlogViewModel
                               {
                                   slugUri = q.SlugUri,
                                   Title = q.Title,
                                   PublishDate = q.PublishDate,
                                   PictureURL = q.PictureURL,
                                   CategoryName = q.Category.CategoryName,

                               }).Take(5).ToListAsync();
            return View(model);
        }
    }
}
