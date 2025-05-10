using Microsoft.AspNetCore.Mvc;

namespace Binary1010Generator.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
