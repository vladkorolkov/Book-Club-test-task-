using BookClub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookClub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BooksContext Db;
        public HomeController(ILogger<HomeController> logger, BooksContext db)
        {
            _logger = logger;
            Db = db;
        }

        public List<string> Index()
        {
            var q = Db.Books.Take(3).Select(x=>x.Name).ToList();
            return q;
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