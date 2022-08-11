using BlogApp.Models;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class LastModifiedPostsViewComponent : ViewComponent
    {
        private readonly BlogDbContext context;
        public LastModifiedPostsViewComponent(BlogDbContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await (from q in context.Articles
                               orderby q.PublishDate descending
                               select new LastModifiedPostsViewModel
                               {
                                   slugUri = q.SlugUri,
                                   PictureURL = q.PictureURL,
                                   Title = q.Title,

                               }).Take(9).ToListAsync();
            return View(model);
        }


    }
}
