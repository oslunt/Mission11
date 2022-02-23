using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission7.Models;
using Mission7.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookCat, int pageNum = 1)
        {
            int pageSize = 10;

            var temp = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookCat || bookCat == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCat == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == bookCat).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(temp);
        }
    }
}
