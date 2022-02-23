using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Components
{
    public class CatsViewComponent : ViewComponent 
    {
        private IBookstoreRepository repo { get; set; }

        public CatsViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCat = RouteData?.Values["bookCat"];

            var cats = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(cats);
        }
    }
}
