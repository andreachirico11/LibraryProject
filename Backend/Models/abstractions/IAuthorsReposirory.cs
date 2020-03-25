using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface IAuthorsRepository
    {
        IQueryable<Authors> Authors { get; set; }
        DBLibraryContext context { get; set; }
        Task<List<AuthorDTO>> GetAllAuthors ();
        Task<AuthorDTO> GetAuthorById (long id);
        
        Task<int> InsertNewAuthor (BookDTO newBook);
        Task<int> DeleteAuthorById (long id);
    }
}