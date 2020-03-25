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

        public IBooksRepository BooksRepo { get; set; }
        public EfUnitOfWork(IBooksRepository bookR) 
        {
            this.BooksRepo = bookR;
        }



        public Task<List<BookDTO>> GetAllBooks()
        {
            return this.BooksRepo.GetAllBooks();
        } 

        public Task<BookDTO> GetBookById(long id)
        {
            return this.BooksRepo.GetBookById(id);
        }

        public Task<int> InsertBook(BookDTO newBook)
        {
            return this.BooksRepo.InsertNewBook(newBook);
        }


































        // public Task<int> InsertBook(Books newBook)
        // {
        //     Task<int> success;
        //     try
        //     {
        //         context.Add(newBook);
        //         success = context.SaveChangesAsync();
        //         Console.WriteLine(success);
        //         return success;
        //     }
        //     catch (System.Exception)
        //     {
        //         Console.WriteLine("Inserterror");                   
        //         throw;
        //     }
        // }
        // public Task<int> UpdateBook( Books updatedBook)
        // {   
        //     Task<int> success;        
        //     try
        //     {
        //         // DeleteBook(id);
        //         // return InsertBook(updatedBook);
        //         context.Update<Books>(updatedBook);
        //         // return  GetBookById(id);
        //         success = context.SaveChangesAsync();
        //         return success;
                
        //     }
        //     catch 
        //     {
        //         Console.WriteLine("Updateerror"); 
        //         throw;
        //     }
        // }
        // public async Task<int> DeleteBook(long id)
        // {
        //     try
        //     {
        //         context.Remove(await GetBookById(id));
        //         return await context.SaveChangesAsync();                
        //     }
        //     catch 
        //     {
        //         Console.WriteLine("Deleteerror"); 
        //         throw;
        //     }
        // }
    }
}