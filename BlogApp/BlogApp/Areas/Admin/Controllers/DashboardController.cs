using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Areas.Admin
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index() => View();

    }
}
