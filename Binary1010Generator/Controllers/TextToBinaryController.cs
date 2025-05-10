using Microsoft.AspNetCore.Mvc;

namespace Binary1010Generator.Controllers
{
    public class TextToBinaryController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
