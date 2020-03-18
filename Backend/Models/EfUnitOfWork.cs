using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Backend.Models 
{
    public class EfUnitOfWork: IUnitOfWork
    {
        DBLibraryContext context = new DBLibraryContext();


        public async Task<List<Books>> GetAllBooks() 
        {
            var books =  context.Books.Select( b => new Books() {
                IdBook = b.IdBook,
                Title = b.Title,
                Editor = b.Editor,
                PublishingYear = b.PublishingYear,
                IdGenre = b.IdGenre,
                IdAuthor = b.IdAuthor,
                Description = b.Description,
                Isbn = b.Isbn
            }).ToList<Books>();

            return books;
        }
    }
}