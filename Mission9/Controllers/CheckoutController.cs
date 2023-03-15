using Microsoft.AspNetCore.Mvc;
using Mission9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Controllers
{
    public class CheckoutController : Controller
    {
        private Basket basket { get; set; }

        public CheckoutController()
        {

        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = basket.Items.ToArray();
                repo.SaveDonation(purchase);
                basket.ClearBasket();

                return RedirectToPage("/DonationCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
