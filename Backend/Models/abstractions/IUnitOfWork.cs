  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface IUnitOfWork
    {
        Task<List<Books>> GetAllBooks();
        Task<Books> GetBookById(long id);
        Task<int> InsertBook(Books newBook);
        Task<int> UpdateBook(Books updatedBook);
        Task<int> DeleteBook(long id);
    }
}