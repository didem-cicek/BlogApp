using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfilesController : Controller
    {
        private readonly BlogDbContext _context;
        public ProfilesController(BlogDbContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index() => View();
    }
}
