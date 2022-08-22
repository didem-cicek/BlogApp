using BlogApp.Models;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class MostPopularViewComponent : ViewComponent
    {
        private readonly BlogDbContext context;

        public MostPopularViewComponent(BlogDbContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await (from q in context.Articles
                               where q.Status == true
                               orderby q.Views descending
                               select new MostPopularViewModel
                               {
                                  slugUri = q.SlugUri,
                                  Title = q.Title,
                                  PublishDate = q.PublishDate,
                                  PictureUrl = q.PictureURL

                               }).Take(5).ToListAsync();
            return View(model);
        }

    }
}
