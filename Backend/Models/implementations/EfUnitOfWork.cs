using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;




namespace Backend.Models
{
    public class EfUnitOfWork : IUnitOfWork
    {
        DBLibraryContext context = new DBLibraryContext();

        public IBooksRepository BooksRepo { get; set; }
        public IUserRepository UserRepo { get; set; }
        public IBorrowRepository BorrowRepo { get; set; }
        public IUserFavouritesRepository UserFavRepo { get; set; }
        public EfUnitOfWork(IBooksRepository bookR, IUserRepository userR, IUserFavouritesRepository userFav, IBorrowRepository borrowR)
        {
            this.BooksRepo = bookR;
            this.UserRepo = userR;
            this.UserFavRepo = userFav;
            this.BorrowRepo = borrowR;
        }



        public Task<List<BookDTO>> GetAllBooks()
        {
            return this.BooksRepo.GetAllBooks();
        }
        public Task<BookDTO> GetBookById(long id)
        {
            return this.BooksRepo.GetBookById(id);
        }
        public Task<bool> InsertBook(BookDTO newBook)
        {
            return this.BooksRepo.InsertNewBook(newBook);
        }



        
        public Task<List<UserDTO>> GetAllUsers() 
        {
            return this.UserRepo.GetAllUsers();
        }
        public Task<UserDTO> FindUserByCredentials(Credentials credentials)
        {
            return this.UserRepo.FindUserByCredentials(credentials);
        }
        public Task<UserDTO> GetUserById(long id)
        {
            return this.UserRepo.GetUserById(id);
        }




        public Task<int> AddBookToUserFavourites(BookAndUserIds bookAndUser)
        {
            return this.UserFavRepo.addBookToUserFavourites(bookAndUser);
        }
        public Task<int> RemoveBookToUserFavourites(BookAndUserIds bookAndUser)
        {
            return this.UserFavRepo.RemoveBookFromUserFavourites(bookAndUser);
        }
        public Task<UserDTO> InsertNewUser(Users newUser)
        {
            return this.UserRepo.InsertNewUser(newUser);
        }





        public Task<bool> BorrowBook(BookAndUserIds bookAndUser)
        {
            return this.BorrowRepo.BorrowBook(bookAndUser);
        }
        public Task<List<LoanDTO>> GetAllLoans()
        {
            return this.BorrowRepo.GetAllLoans();
        }




        public Task<List<LoanDTO>> GetAllLoansByUserId(long idUser)
        {
            return this.BorrowRepo.GetAllLoansByUserId(idUser);
        }
        public Task<bool> DeleteLoan(long idBook)
        {
            return this.BorrowRepo.DeleteLoan(idBook);
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