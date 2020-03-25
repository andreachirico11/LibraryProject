  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models {
    public interface IBookRepository
    {   
        IQueryable<Books> Books {get; set;}
        DBLibraryContext context {get; set;}
        Task<List<BookDTO>> GetAllBooks ();
        Task<Books> GetBookById ();
        
        Task<int> InsertNewBook (Books newBook);
        Task<int> UpdateBook (Books newBook);
        Task<int> DeleteBookById (long id);
        

    }
}