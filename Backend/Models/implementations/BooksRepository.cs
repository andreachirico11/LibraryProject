using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class BookRepository : IBookRepository
    {
        public IQueryable<Books> Books { get; set; }
        public DBLibraryContext context { get; set; }

        public BookRepository (DBLibraryContext ctx) 
        {
            this.context = ctx;
            this.Books = ctx.Books;
        }



        public Task<List<BookDTO>> GetAllBooks()
        {
            // throw new NotImplementedException();
            try
            {
                var books = context.Books
                        .Include( b => b.IdAuthorNavigation)
                        .Include( b => b.IdGenreNavigation)
                        .Select( b =>  new BookDTO(b, b.IdGenreNavigation, b.IdAuthorNavigation)
                        ).ToListAsync();
                return books;
            }
            catch 
            {
                Console.WriteLine("getallbooks error");
                throw;
            }
        }
        public Task<Books> GetBookById()
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertNewBook(Books newBook)
        {
            throw new NotImplementedException();
        }
        public Task<int> UpdateBook(Books newBook)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteBookById(long id)
        {
            throw new NotImplementedException();
        }
    }
}