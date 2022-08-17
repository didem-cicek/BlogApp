using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingsController : Controller
    {
        private readonly BlogDbContext _context;
        public SettingsController(BlogDbContext _context)
        {
            this._context = _context;
        }
        public IActionResult Index() => View();
    }
}
