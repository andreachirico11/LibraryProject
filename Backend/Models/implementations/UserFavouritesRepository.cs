using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class UserFavouritesRepository : IUserFavouritesRepository
    {
        public DBLibraryContext context { get; set; }
        public UserFavouritesRepository(DBLibraryContext ctx)
        {
            this.context = ctx;
        }

        public async Task<bool> VerifyIfBookIsAlreadyInFavourites(long idBook, long idUser)
        {
            UserFavourites foundRelation = null;
            foundRelation = await context.UserFavourites
                                        .Where(uf => uf.IdUser == idUser && uf.IdBook == idBook)
                                        .FirstOrDefaultAsync();
            return foundRelation != null ? true : false;
        }

        public async Task<long> getMaxId()
        {
            return await this.context.UserFavourites
                                .OrderByDescending(uf => uf.IdFav)
                                .Select(uf => uf.IdFav)
                                .FirstOrDefaultAsync();
        }

        public async Task<int> addBookToUserFavourites(BookAndUserIds bookAndUser)
        {
            bool alreadyInserted = await this.VerifyIfBookIsAlreadyInFavourites(bookAndUser.idBook, bookAndUser.idUser);
            if (alreadyInserted == false)
            {
                var maxId = await this.getMaxId() + 1;
                this.context.UserFavourites.Add(new UserFavourites(maxId, bookAndUser.idBook, bookAndUser.idUser));
                return await this.context.SaveChangesAsync();
            }
            else
            {
                return await this.context.SaveChangesAsync();
            }
        }


    }

    public class BookAndUserIds
    {
        public long idBook { get; set; }
        public long idUser { get; set; }
    }
}