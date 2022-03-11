using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project7.Models
{
    // this is a template for a class (interface isn't an actual class)
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
        public void SaveBook(Book b);
        public void CreateBook(Book b);
        public void DeleteBook(Book b);
    }
}
