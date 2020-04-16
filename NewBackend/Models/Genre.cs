using System;
using System.Collections.Generic;

namespace NewBackend.Models
{
    public partial class Genre
    {

        public int IdGenre { get; set; }
        public string Name { get; set; }

    }

}

        // public virtual ICollection<Books> Books { get; set; }
        // public Genres()
        // {
        //     Books = new HashSet<Books>();
        // }
        // public Genres(long id , string name)
        // {
        //     this.IdGenre = id;
        //     this.Name = name;
        // }