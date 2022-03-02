using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart c)
        {
            cart = c;
        }
        public IViewComponentResult Invoke()
        {
            //cart.Items.Count();
            return View(cart);
        }
    }
}
