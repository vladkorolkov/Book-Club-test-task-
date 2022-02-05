using BookClub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace BookClub.Controllers
{
    public class BooksController : Controller
    {
        BooksContext Db;
        public BooksController(BooksContext db)
        {
            Db = db;
        }

        
        public IActionResult MyBooks()
        {
            var allbooks = Db.Books.ToList();
            return View(allbooks);
        }

        public string MarkAsRead()
        {
            string test = "marked";
            return test;
        }

    }
}
