using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    internal class SplittedAuthorName
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public SplittedAuthorName(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
    public class AuthorsRepository : IAuthorsRepository
    {
        public IQueryable<Authors> Authors { get; set; }
        public DBLibraryContext context { get; set; }
        public AuthorsRepository(DBLibraryContext ctx)
        {
            this.context = ctx;
            this.Authors = ctx.Authors;
        }


        public Task<List<AuthorDTO>> GetAllAuthors()
        {
            throw new NotImplementedException();
        }
        public async Task<AuthorDTO> GetAuthorByCompleteName(string fullName)
        {
            // var splitNames = fullName.Split(' ');
            // var name = splitNames[0];
            // var surname = splitNames[1];
            SplittedAuthorName objectName = NameSplitter(fullName);
            var author = await this.Authors.Where(a => a.Name == objectName.Name && a.Surname == objectName.Surname)
                                            .Select(a => new AuthorDTO(a))
                                            .FirstOrDefaultAsync();
            return author;
        }

        public async Task<long> InsertNewAuthor(string newAuthorFullName)
        {
            // var splitNames = newAuthorFullName.Split(' ');
            // var name = splitNames[0];
            // var surname = splitNames[1];

            SplittedAuthorName objectName = NameSplitter(newAuthorFullName);

            var id = await this.GetMaxID() + 1;
            this.context.Authors.Add(new Authors(id, objectName.Name, objectName.Surname));
            context.SaveChangesAsync(); 
            return id;
        }









        public Task<int> DeleteAuthorById(long id)
        {
            throw new NotImplementedException();
        }
        public async Task<long> GetMaxID()
        {
            var lastOne = await this.context.Authors.OrderByDescending(g => g.IdAuthor).FirstOrDefaultAsync();
            return lastOne.IdAuthor;
        }

        internal SplittedAuthorName NameSplitter(string fullName)
        {
            SplittedAuthorName splittedResult;
            string[] splittedNameArray = fullName.Split(' ');
            var count = splittedNameArray.Length;
            switch (count)
            {   
                case 1:
                splittedResult = new SplittedAuthorName(splittedNameArray[0], splittedNameArray[0]);
                break;
                case 2:
                splittedResult = new SplittedAuthorName(splittedNameArray[0], splittedNameArray[1]);
                break;
                case 3:
                splittedResult = new SplittedAuthorName(splittedNameArray[0], splittedNameArray[1] + ' ' + splittedNameArray[2]);
                break;                
                default:
                splittedResult = new SplittedAuthorName( "Wrong", "Name" );
                break;
            }
            return splittedResult;
        }
    }
}