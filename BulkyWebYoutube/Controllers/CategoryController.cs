using Microsoft.AspNetCore.Mvc;

namespace BulkyWebYoutube.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
