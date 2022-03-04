using Microsoft.AspNetCore.Mvc;
using Project7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project7.Controllers
{
    public class OrderController : Controller
    {
        private ICheckoutRepository repo { get; set; }
        private Basket basket { get; set; }

        public OrderController(ICheckoutRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult PlaceOrder()
        {
            return View(new Checkout());
        }
        [HttpPost]
        public IActionResult PlaceOrder(Checkout check)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }
            if (ModelState.IsValid)
            {
                check.Lines = basket.Items.ToArray();
                repo.SaveOrder(check);
                basket.ClearBasket();

                return RedirectToPage("/Completed");
            }
            else
            {
                return View();
            }
        }
    }
}
