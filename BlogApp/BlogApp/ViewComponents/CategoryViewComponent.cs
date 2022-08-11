using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly BlogDbContext context;
        public CategoryViewComponent(BlogDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> tags = await (from q in context.Categories
                                    select q).ToListAsync();


            return View(tags);
        }
    }
}
