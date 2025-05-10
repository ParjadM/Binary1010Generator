using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using Binary1010Generator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Binary1010Generator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/TheLoopEternal.txt");
            string content = System.IO.File.ReadAllText(filePath);
            ViewBag.FileContent = content;
            return View();
        }
        [HttpPost]
        public IActionResult GenerateBinary(string fav_language, int size)
        {
            string text = GenerateText(fav_language, size);
            string binaryText = ConvertToBinary(text);

            return Content(binaryText);
        }
        private string GenerateText(string type, int size)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/TheLoopEternal.txt");

            if (!System.IO.File.Exists(filePath)) return "File not found";

            string content = System.IO.File.ReadAllText(filePath);

            if (type == "Word") return GetRandomWords(content, size);
            if (type == "Sentence") return GetRandomSentences(content, size);
            if (type == "Paragraph") return GetRandomParagraphs(content, size);

            return "Invalid selection";
        }

        private string ConvertToBinary(string text)
        {
            text = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(text));
            return string.Join(" ", text.Select(c => Convert.ToString(c, 2).PadLeft(8, '0')));
        }
        private string GetRandomWords(string content, int size)
        {
            string[] words = Regex.Replace(content, @"[^\w\s']", "").Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            if (size > words.Length) size = words.Length; 

            return string.Join(" ", words.OrderBy(_ => Guid.NewGuid()).Take(size));
        }

        private string GetRandomSentences(string content, int size)
        {
            string[] sentences = content.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            if (size > sentences.Length) size = sentences.Length; 
            return string.Join(". ", sentences.OrderBy(_ => Guid.NewGuid()).Take(size)) + ".";
        }

        private string GetRandomParagraphs(string content, int size)
        {
            string[] paragraphs = content.Split(new[] { "\n\n", "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (size > paragraphs.Length) size = paragraphs.Length; 

            return string.Join("\n\n", paragraphs.OrderBy(_ => Guid.NewGuid()).Take(size));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
