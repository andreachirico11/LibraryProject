using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewBackend.Models;
using NewBackend;
using Microsoft.EntityFrameworkCore;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        public UsersController(NewBackendDbContext ctx)
        {
            this.ctx = ctx;
        }

        public NewBackendDbContext ctx { get; set; }

        [HttpGet]
        public async Task<List<UserDTO>> GetAllUsers()
        {
            return await ctx.Users.Select(u => new UserDTO(u)).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<UserDTO> GetUserById(int id)
        {
            return await ctx.Users
                        .Where(u => u.IdUser == id)
                        .Include(u => u.FavouritesUserBooks)
                        .ThenInclude(userfav => userfav.Book)
                        .ThenInclude(b => b.Genre)
                        .Include(u => u.FavouritesUserBooks)
                        .ThenInclude(userfav => userfav.Book)
                        .ThenInclude(b => b.Author)
                        .Select(u => new UserDTO(u))
                        .FirstOrDefaultAsync();
        }
        [HttpPost("auth")]
        public async Task<UserDTO> AuthorizeUser(Credentials credentials)
        {

            var userToAutenticate = await ctx.Users
                       .Where(u => u.Password == credentials.Password && u.Email == credentials.Email)
                       .FirstOrDefaultAsync();

            if (userToAutenticate != null)
            {
                return await this.GetUserById(userToAutenticate.IdUser);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public async Task<UserDTO> InsertNewUser(UserDTO newUser)
        {
            
            var credentials = new Credentials(newUser.Password, newUser.Email);
            var alreadyRegistered = await this.AuthorizeUser(credentials);

            if (alreadyRegistered == null)
            {
                ctx.Users.Add( new User(newUser));
                await ctx.SaveChangesAsync();
                return newUser;          
        
            }
            return null;
        }






        // public async Task<int> getMaxId()
        // {
        //     return await this.ctx.Users
        //                         .OrderByDescending(u => u.IdUser)
        //                         .Select(uf => uf.IdUser)
        //                         .FirstOrDefaultAsync();
        // }


    }


}

