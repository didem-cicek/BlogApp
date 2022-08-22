using BlogApp.Models;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class BlogListViewComponent : ViewComponent
    {
        private readonly BlogDbContext context;

        public BlogListViewComponent(BlogDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string categoryName = null)
        {


            var model = new List<BlogListViewModel>();
            if (categoryName == null)
            {
                model = await (from q in context.Articles.Include(c => c.Category)
                               where q.Status == true
                               select new BlogListViewModel
                               {
                                   Author = q.AuthorName,
                                   BlogBody = q.Body,
                                   PictureURL = q.PictureURL,
                                   PublishedDate = q.PublishDate,
                                   SlugUri = q.SlugUri,
                                   Title = q.Title,

                               }).Take(5).ToListAsync();
            }


            return View(model);
        }
    }
}
