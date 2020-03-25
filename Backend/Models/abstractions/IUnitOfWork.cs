  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface IUnitOfWork
    {
        IBookRepository BooksRepo { get; set; }
        // Task<IQueryable<string>> GetAllBooks();
        // Task<Books> GetBookById(long id);
        // Task<int> InsertBook(Books newBook);
        // Task<int> UpdateBook(Books updatedBook);
        // Task<int> DeleteBook(long id);
        Task<List<BookDTO>> GetAllBooks();
    }
}