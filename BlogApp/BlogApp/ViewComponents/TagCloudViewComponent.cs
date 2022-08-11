using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class TagCloudViewComponent : ViewComponent
    {
        private readonly BlogDbContext context;
        public TagCloudViewComponent(BlogDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Tag> tags = await (from q in context.Tags
                                    select q).ToListAsync();


            return View(tags);
        }
    }
}
