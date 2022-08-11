using BlogApp.Models;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class SingleViewComponent : ViewComponent
    {
        private readonly BlogDbContext context;
        public SingleViewComponent(BlogDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string Title)
        {
            var model = await (from q in context.Articles.Include(a=>a.Title)
                               where q.Title == Title
                               select new SingleViewModel
                               {
                                  Title = q.Title,
                                  PublishDate = q.PublishDate,
                                  PictureURL = q.PictureURL,
                                  Body = q.Body,

                               }).ToListAsync();
            return View(model);
        }
    }
}
