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
        Task<AuthorDTO> GetAuthorByCompleteName (string fullName);
        
        Task<long> InsertNewAuthor (string newAuthorFullName);
        Task<int> DeleteAuthorById (long id);
    }
}