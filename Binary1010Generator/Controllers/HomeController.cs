using Microsoft.AspNetCore.Mvc;
using BinGen = Binary1010GeneratorLib.Binary1010Generator;

namespace Binary1010Generator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("/")]
        public IActionResult GenerateBinary(string fav_language, int size)
        {
            int type;
            if (fav_language == "Word")
            {
                type = 1;
            }
            else if (fav_language == "Sentence")
            {
                type = 2;
            }
            else if (fav_language == "Paragraph")
            {
                type = 3;
            }
            else
            {
                type = -1;
            }

            if (type == -1)
            {
                return BadRequest("Invalid selection!");
            }

            
            string binaryOutput = BinGen.GenerateBinary(type, size);

            return Content(binaryOutput, "text/plain");
        }
    }
}
