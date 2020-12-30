using System.Collections.Generic;
using Books.Models;

namespace Books.Data
{   
    public interface IBookRepo
    {
        bool SaveChanges();

        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);

    }
}