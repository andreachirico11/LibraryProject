using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public interface IUserRepository
    {
        DBLibraryContext Context {get; set; }
        Task<UserDTO> InsertNewUser(Users newUser); 
        Task<UserDTO> FindUserByCredentials(Credentials credentials);
        Task<UserDTO> GetUserById(long id);
        Task<List<UserDTO>> GetAllUsers();
    }
}