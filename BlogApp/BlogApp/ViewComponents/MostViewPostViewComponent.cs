using BlogApp.Models;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class MostViewPostViewComponent : ViewComponent
    {
        private readonly BlogDbContext context;

        public MostViewPostViewComponent(BlogDbContext context) { this.context = context; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await (from q in context.Articles
                               where q.Status == true
                               orderby q.Views descending
                               select new MostViewPostViewModel
                               {
                                   slugUri = q.SlugUri,
                                   Title = q.Title,
                                   PublishDate = q.PublishDate,

                               }).Take(4).ToListAsync();
            return View(model);
        }
    }
}
