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
        public IGenresRepository GenresRepository { get; set; }
        public  IAuthorsRepository AuthorsRepository { get; set; }
        public DBLibraryContext context { get; set; }

        public BooksRepository(DBLibraryContext ctx, IGenresRepository genRepo,  IAuthorsRepository authorsRepository)
        {
            this.context = ctx;
            this.Books = ctx.Books;
            this.GenresRepository = genRepo;
            this.AuthorsRepository = authorsRepository;
        }



        public async Task<List<BookDTO>> GetAllBooks()
        {
            try
            {
                var books = await context.Books
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

        public async Task<bool> InsertNewBook(BookDTO newBook)
        {
            var id = await this.GetMaxID() + 1;
            newBook.IdBook = id;
            Books book;
            long idGen;
            long idAuth;
            
            var genre = await GenresRepository.GetGenreByName(newBook.Genre);
            if (genre == null)
            {
                idGen = await this.GenresRepository.InsertNewGenre(newBook.Genre);
            }
            else
            {
                idGen = genre.IdGenre;
            }

            var author = await AuthorsRepository.GetAuthorByCompleteName(newBook.Author);
            if(author == null)
            {
                idAuth = await this.AuthorsRepository.InsertNewAuthor(newBook.Author);
            }
            else
            {
                idAuth = author.IdAuthor;
            }

            book = new Books(newBook, idGen, idAuth);
            context.Add(book);
            await context.SaveChangesAsync();
            return true;
        }






        public Task<int> UpdateBook(BookDTO newBook)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteBookById(long id)
        {
            throw new NotImplementedException();
        }
        public async Task<long> GetMaxID()
        {
            var lastGenre = await this.context.Books.OrderByDescending(g => g.IdBook).FirstOrDefaultAsync();
            return lastGenre.IdBook;
        }
    }
}