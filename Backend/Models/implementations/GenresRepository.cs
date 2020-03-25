using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class GenresRepository : IGenresRepository
    {
        public IQueryable<Genres> Genres { get; set; }
        public DBLibraryContext context { get; set; }
        public GenresRepository(DBLibraryContext ctx)
        {
            this.context = ctx;
            this.Genres = ctx.Genres;
        }

        
        public async Task<List<GenreDTO>> GetAllGenres()
        {
            try
            {
                var genres = await context.Genres
                                        .Select(g => new GenreDTO(g))
                                        .ToListAsync();
                return genres;
            }
            catch 
            {
                Console.WriteLine("getallgenres error");
                throw;
            }
        }
        public async Task<GenreDTO> GetGenreByName(string name)
        {
            var genre = await this.Genres.Where( g => g.Name == name)
                                    .Select(g => new GenreDTO(g))
                                    .FirstOrDefaultAsync();
            return genre;
        }

        public async Task<long> InsertNewGenre(string newGenre)
        {
            var id = await this.GetMaxID() + 1;
            this.context.Genres.Add( new Genres(id , newGenre));
            context.SaveChangesAsync();
            var gen =  await this.GetGenreByName(newGenre);
            return gen.IdGenre;
        }
        public Task<int> DeleteGenreById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<long> GetMaxID() 
        {
            var lastGenre = await this.context.Genres.OrderByDescending( g => g.IdGenre).FirstOrDefaultAsync();
            System.Console.WriteLine(lastGenre);
            return lastGenre.IdGenre;
        }
    }
}