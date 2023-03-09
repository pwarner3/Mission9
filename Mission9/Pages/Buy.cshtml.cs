using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9.Infrastructure;
using Mission9.Models;

namespace Mission9.Pages
{
    public class BuyModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public BuyModel(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket")
                ?? new Basket();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book book = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(book, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
