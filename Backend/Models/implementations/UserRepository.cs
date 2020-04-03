using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class UserRepository : IUserRepository
    {
        public DBLibraryContext Context { get; set; }
        public IBooksRepository BookRepo { get; set; }
        public UserRepository(DBLibraryContext ctx, IBooksRepository bookr)
        {
            this.Context = ctx;
            this.BookRepo = bookr;
        }


        public Task<UserDTO> InsertNewUser(UserDTO newUser)
        {
            throw new NotImplementedException();
        }
        public async Task<UserDTO> FindUserByCredentials(Credentials credential)
        {
            try
            {
               
                var user = await Context.Users
                           .Where(u => u.Password == credential.Password && u.Email == credential.Email)
                           .FirstOrDefaultAsync();

                if (user != null)
                {
                    return await this.GetUserById(user.IdUser);
                    // return user;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                Console.WriteLine("authenticateuser error");
                throw;
            }
        }

        public async Task<UserDTO> GetUserById(long id)
        {
            try
            {
                var foundUser = await Context.Users
                            .Where(u => u.IdUser == id)
                            .Include(u => u.Favourites)
                            .FirstOrDefaultAsync();
                var favBooks = new List<BookDTO>();

                foreach (var UsFav in foundUser.Favourites)
                {
                    BookDTO book = await this.BookRepo.GetBookById(UsFav.IdBook);
                    favBooks.Add(book);
                }
                
                return new UserDTO(foundUser, favBooks);
            }
            catch
            {
                Console.WriteLine("getuserbyid error");
                throw;
            }
        }



    }

    public class Credentials
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}