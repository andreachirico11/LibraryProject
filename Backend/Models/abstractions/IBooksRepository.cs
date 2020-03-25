using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models {
    public interface IBooksRepository
    {   
        IQueryable<Books> Books {get; set;}
        DBLibraryContext context {get; set;}
        Task<List<BookDTO>> GetAllBooks ();
        Task<BookDTO> GetBookById (long id);
        
        Task<bool> InsertNewBook (BookDTO newBook);
        Task<int> UpdateBook (BookDTO newBook);
        Task<int> DeleteBookById (long id);
        
    }
}