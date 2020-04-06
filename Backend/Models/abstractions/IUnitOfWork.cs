
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface IUnitOfWork
    {
        IBooksRepository BooksRepo { get; set; }
        IUserRepository UserRepo { get; set; }
        IUserFavouritesRepository UserFavRepo { get; set; }


        Task<List<BookDTO>> GetAllBooks();
        Task<BookDTO> GetBookById(long id);
        Task<bool> InsertBook(BookDTO newBook);


        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(long id);
        Task<UserDTO> FindUserByCredentials(Credentials credentials);
        
        
        Task<int> AddBookToUserFavourites(BookAndUserIds bookAndUser);
        Task<int> RemoveBookToUserFavourites(BookAndUserIds bookAndUser);
        
        
        Task<bool> BorrowBook(BookAndUserIds bookAndUser);
        Task<List<LoanDTO>> GetAllLoans();
        
        
        Task<List<LoanDTO>> GetAllLoansByUserId(long idUser);
        Task<bool> DeleteLoan(long idBook);
    }
}