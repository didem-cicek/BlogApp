using BlogApp.Models;
using BlogApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class MosaicGridBlogListViewComponent : ViewComponent
    {
        private readonly BlogDbContext context;

        public MosaicGridBlogListViewComponent(BlogDbContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync (string categoryName = null)
        {
            var model = new List<MosaicGridBlogListViewModel>();
            if (categoryName == null)
            {
                model = await (from q in context.Articles.Include(c => c.Category)
                               select new MosaicGridBlogListViewModel
                               {
                                   SlugUri = q.SlugUri,
                                   Title = q.Title,
                                   PublishDate = q.PublishDate,
                                   PictureURL = q.PictureURL,
                               }).Take(4).ToListAsync();
            }
            return View(model);
        }

    }
}
