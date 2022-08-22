using BlogApp.Models;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class TopTrendingViewComponent : ViewComponent
    {
        private readonly BlogDbContext context;
        public TopTrendingViewComponent(BlogDbContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await (from q in context.Articles
                               where q.Status == true
                               orderby q.Views descending
                               select new TopTrendingViewModel
                               {
                                   slugUri = q.SlugUri,
                                   PublishDate = q.PublishDate,
                                   Title = q.Title,

                               }).Take(1).ToListAsync();
            return View(model);
        }
    }
}
