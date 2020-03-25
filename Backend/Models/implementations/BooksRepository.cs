using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class BooksRepository : IBooksRepository
    {
        public IQueryable<Books> Books { get; set; }
        public DBLibraryContext context { get; set; }

        public BooksRepository(DBLibraryContext ctx)
        {
            this.context = ctx;
            this.Books = ctx.Books;
        }



        public Task<List<BookDTO>> GetAllBooks()
        {
            try
            {
                var books = context.Books
                        .Include(b => b.IdAuthorNavigation)
                        .Include(b => b.IdGenreNavigation)
                        .Select(b => new BookDTO(b, b.IdGenreNavigation, b.IdAuthorNavigation)
                        ).ToListAsync();
                return books;
            }
            catch
            {
                Console.WriteLine("getallbooks error");
                throw;
            }
        }
        public Task<BookDTO> GetBookById(long id)
        {
            try
            {
                var book = context.Books
                       .Include(b => b.IdAuthorNavigation)
                       .Include(b => b.IdGenreNavigation)
                       .Where(b => b.IdBook == id)
                       .Select(b => new BookDTO(b, b.IdGenreNavigation, b.IdAuthorNavigation)
                       ).FirstOrDefaultAsync();
                return book;
            }
            catch
            {
                Console.WriteLine("getallbooksbyid error");
                throw;
            }
        }

        public Task<int> InsertNewBook(BookDTO newBook)
        {
            Task<int> success;
            Books book;
            long idGen = 1;
            long idAuth = 1;
            var genres = this.context.Genres.Where(g => g.Name == newBook.Genre);

            book = new Books(newBook, idGen, idAuth);
            context.Add(book);
            success = context.SaveChangesAsync();
            Console.WriteLine(success);
            return success;
            // throw new NotImplementedException();
        }
        public Task<int> UpdateBook(BookDTO newBook)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteBookById(long id)
        {
            throw new NotImplementedException();
        }
    }
}