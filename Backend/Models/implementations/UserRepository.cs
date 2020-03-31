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
        public UserRepository(DBLibraryContext ctx)
        {
            this.Context = ctx;
        }

        
        public Task<UserDTO> InsertNewUser(UserDTO newUser)
        {
            throw new NotImplementedException();
        }
        public  Task<UserDTO> FindUserByCredentials(Credentials credential)
        {
            try
            {
                Task<UserDTO> user;
                user = Context.Users
                           .Where(u => u.Password == credential.Password && u.Email == credential.Email)
                           .Select(u => new UserDTO(u))
                           .FirstOrDefaultAsync();
                if (user != null)
                {
                    return user; 
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

    }

    public class Credentials
    {
        public string Password { get; set; }
        public string Email { get; set; } 
    }
}