using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index() => View();
        [HttpGet("~/article/{slugUri}")]
        public IActionResult Single(string slugUri) => View();
        [HttpGet("~/tag/{tagslug}")]
        public IActionResult GetByTag(string tagslug)
        {
            return View();
        }
        [HttpGet("~/category/{categoryName}")]
        public IActionResult GetByCategory(string categoryName)
        {
            return View();
        }
    }
}
