using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class AuthorsRepository : IAuthorsRepository
    {
        public IQueryable<Authors> Authors { get; set; }
        public DBLibraryContext context { get; set; }
        public AuthorsRepository(DBLibraryContext ctx)
        {
            this.context = ctx;
            this.Authors = ctx.Authors;
        }

        
        public Task<List<AuthorDTO>> GetAllAuthors()
        {
            throw new NotImplementedException();
        }
        public Task<AuthorDTO> GetAuthorById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertNewAuthor(BookDTO newBook)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAuthorById(long id)
        {
            throw new NotImplementedException();
        }
    }
}