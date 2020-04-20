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


        public async Task<UserDTO> InsertNewUser(Users newUser)
        {
            var credentials = new Credentials(newUser.Password, newUser.Email);
            var alreadyRegistered = await this.FindUserByCredentials(credentials);

            if (alreadyRegistered == null)
            {
                newUser.IdUser = await getMaxId() + 1;
                newUser.IsAdmin = 0;
                Context.Users.Add(newUser);
                await Context.SaveChangesAsync();
                return new UserDTO(newUser);
            }
            return null;
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

        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                return await Context.Users.Select(u => new UserDTO(u)).ToListAsync();
            }
            catch
            {
                Console.WriteLine("getallUsers error");
                throw;
            }
        }

        public async Task<long> getMaxId()
        {
            return await this.Context.Users
                                .OrderByDescending(u => u.IdUser)
                                .Select(uf => uf.IdUser)
                                .FirstOrDefaultAsync();
        }



    }

    public class Credentials
    {
        public Credentials(string password, string email)
        {
            Password = password;
            Email = email;
        }

        public string Password { get; set; }
        public string Email { get; set; }
    }
}