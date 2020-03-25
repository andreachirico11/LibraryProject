using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;




namespace Backend.Models 
{
    public class EfUnitOfWork: IUnitOfWork
    {
        DBLibraryContext context = new DBLibraryContext();

        public IBookRepository BooksRepo { get; set; }
        public EfUnitOfWork(IBookRepository bookR) 
        {
            this.BooksRepo = bookR;
        }
        // public async Task<IQueryable<string>> GetAllBooks() 
        // {
        //     try {
        //         var books = context.Books
        //                     .Include(b => b.IdAuthorNavigation)
        //                     .Select(b => b.IdAuthorNavigation.Name);
        //         return books;
        //     }
        //     catch 
        //     {
        //         Console.WriteLine("getAllError");
        //         throw ;
        //     }
        // }


        public Task<List<BookDTO>> GetAllBooks()
        {
            return this.BooksRepo.GetAllBooks();
        } 

































        public async Task<Books> GetBookById(long id)
        {
            try
            {
                return context.Books.Where( b => b.IdBook == id).FirstOrDefault();                
            }
            catch 
            {
                Console.WriteLine("getByIdError");
                throw;
            }
        }

        public Task<int> InsertBook(Books newBook)
        {
            Task<int> success;
            try
            {
                context.Add(newBook);
                success = context.SaveChangesAsync();
                Console.WriteLine(success);
                return success;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Inserterror");                   
                throw;
            }
        }
        public Task<int> UpdateBook( Books updatedBook)
        {   
            Task<int> success;        
            try
            {
                // DeleteBook(id);
                // return InsertBook(updatedBook);
                context.Update<Books>(updatedBook);
                // return  GetBookById(id);
                success = context.SaveChangesAsync();
                return success;
                
            }
            catch 
            {
                Console.WriteLine("Updateerror"); 
                throw;
            }
        }
        public async Task<int> DeleteBook(long id)
        {
            try
            {
                context.Remove(await GetBookById(id));
                return await context.SaveChangesAsync();                
            }
            catch 
            {
                Console.WriteLine("Deleteerror"); 
                throw;
            }
        }
    }
}