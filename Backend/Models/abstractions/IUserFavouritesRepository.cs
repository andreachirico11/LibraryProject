using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface IUserFavouritesRepository
    {
        DBLibraryContext context { get; set; }
         Task<bool> VerifyIfBookIsAlreadyInFavourites(long idBook, long idUser);
         Task<long> getMaxId();
         Task<int> addBookToUserFavourites(BookAndUserIds bookAndUser);
        
    }
}