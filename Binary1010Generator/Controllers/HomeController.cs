using Microsoft.AspNetCore.Mvc;
using BinGen = Binary1010GeneratorLib.Binary1010Generator;

namespace Binary1010Generator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();

        [HttpPost]
        [Route("Home/GenerateBinary")]
        public IActionResult GenerateBinary(string fav_language, int size)
        {
            int type = fav_language switch
            {
                "Word" => 1,
                "Sentence" => 2,
                "Paragraph" => 3,
                _ => -1
            };

            if (type == -1) return BadRequest("Invalid selection!");

            
            string binaryOutput = Binary1010GeneratorLib.Binary1010Generator.GenerateBinary(type, size);

            return Content(binaryOutput, "text/plain");
        }
    }
}
