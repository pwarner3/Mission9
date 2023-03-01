using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookstoreRepository (BookstoreContext bookstore)
        {
            context = bookstore;
        }

        //Return the IQueryable with the actual context
        public IQueryable<Book> Books => context.Books;
    }
}
