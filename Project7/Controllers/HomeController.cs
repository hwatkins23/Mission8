using Microsoft.AspNetCore.Mvc;
using Project7.Models;
using Project7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project7.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(string Category, int pageNum = 1)
        {
            int pageSize = 10;

            var yeet = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == Category || Category == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    totalNumBooks = (Category == null
                    ? repo.Books.Count()
                    : repo.Books.Where(x => x.Category == Category).Count()),

                    booksPerPage = pageSize,
                    currentPage = pageNum
                }
            };

            return View(yeet);
        }
    }
}
