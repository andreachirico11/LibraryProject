using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Genres
    {
        public Genres()
        {
            Books = new HashSet<Books>();
        }
        public Genres(long id , string name)
        {
            this.IdGenre = id;
            this.Name = name;
        }

        public long IdGenre { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }

}
