using BlogApp.Models;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class QuadrupleCarouselViewComponent : ViewComponent
    {
        private readonly BlogDbContext context;

        public QuadrupleCarouselViewComponent(BlogDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string categoryName)
        {
            var model = await (from q in context.Articles.Include(c => c.Category)
                               where q.Category.CategoryName == categoryName
                               select new QuadrupleCarouselViewModel
                               {
                                   slugUri = q.SlugUri,
                                   AuthorName = q.AuthorName,
                                   CategoryName = q.Category.CategoryName,
                                   PublishDate = q.PublishDate,
                                   PictureURL = q.PictureURL,
                                   Title = q.Title
                               }).Take(5).ToListAsync();
            return View(model);
        }

    }
}
