using System;
using System.Collections.Generic;
using NewBackend.Models;
namespace NewBackend.Models
{
    public partial class Genre
    {

        public int IdGenre { get; set; }
        public string Name { get; set; }


        public Genre()
        {
            Books = new HashSet<Book>();
        }

        public Genre(int idGenre, string name)
        {
            IdGenre = idGenre;
            Name = name;
        }

        public virtual ICollection<Book> Books { get; set; }
    }

}
// public Genres(long id , string name)
// {
//     this.IdGenre = id;
//     this.Name = name;
// }