using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewBackend;
using NewBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    // https://localhost:5001/api/userFavourites/add
    [ApiController]
    [Route("api/[controller]")]
    public class UserFavouritesController : ControllerBase
    {
        public UserFavouritesController(NewBackendDbContext ctx)
        {
            this.ctx = ctx;
        }
        public NewBackendDbContext ctx { get; set; }



        [HttpPost("add")]
        public async Task<int> AddBookToUserFavourites(BookAndUserIds bookAndUser)
        {
            var isPresent = await GetBookFromFav(bookAndUser);
            if (isPresent == null)
            {
                var userToUpdate = await ctx.Users.Where(u => u.IdUser == bookAndUser.idUser).SingleOrDefaultAsync();
                userToUpdate.FavouritesUserBooks.Add(new FavouritesUserBooks(bookAndUser.idUser, bookAndUser.idBook));
                return await ctx.SaveChangesAsync();
            }
            else
            {

                return 0;
            }
        }


        [HttpPost("remove")]
        public async Task<int> RemoveBookToUserFavourites(BookAndUserIds bookAndUser)
        {
            var favToRemove = await GetBookFromFav(bookAndUser);
            if(favToRemove != null)
            {
                ctx.Remove(favToRemove);
                return await ctx.SaveChangesAsync();
            }
            return 0;
        }

        private async Task<FavouritesUserBooks> GetBookFromFav(BookAndUserIds bAndUsId)
        {
            var user = await ctx.Users.Where(uf => uf.IdUser == bAndUsId.idUser)
                                      .FirstOrDefaultAsync();
            return await ctx.Entry(user)
                            .Collection(u => u.FavouritesUserBooks)
                           .Query()
                           .Where(uFav => uFav.IdBook == bAndUsId.idBook)
                           .SingleOrDefaultAsync();
        }


    }
}

