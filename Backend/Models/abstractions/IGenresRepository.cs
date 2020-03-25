using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface IGenresRepository
    {
        IQueryable<Genres> Genres { get; set; }
        DBLibraryContext context { get; set; }
        Task<List<GenreDTO>> GetAllGenres ();
        Task<GenreDTO> GetGenreByName (string name);
        
        Task<long> InsertNewGenre (string newGenre);
        Task<int> DeleteGenreById (long id);
    }
}