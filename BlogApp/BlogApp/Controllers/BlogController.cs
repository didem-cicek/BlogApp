using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Single() => View();
    }
}
