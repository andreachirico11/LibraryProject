
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
        Task<UserDTO> FindUserByCredentials(Credentials credentials);
        Task<UserDTO> GetUserById(long id);
        Task<int> AddBookToUserFavourites(BookAndUserIds bookAndUser);

    }
}