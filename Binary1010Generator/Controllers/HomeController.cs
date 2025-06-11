using Microsoft.AspNetCore.Mvc;
using Binary1010GeneratorLib;
using System.Threading.Tasks;

namespace Binary1010Generator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static async Task<string> GenerateBinary(string fav_language, int size)
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
            else if (fav_language == "Whole")
            {
                type = 3;
            }
            else
            {
                type = -1;
            }

            if (type == -1)
            {
                return "Invalid selection!";
            }

            string test = await Binary1010GeneratorLib.Binary1010Generator.GenerateBinary(type, size);
            return test;
        }
    }
}
