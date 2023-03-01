using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public interface IBookstoreRepository
    {
        //Similar to a list but to only read data in a better way
        IQueryable<Book> Books { get; }
    }
}
