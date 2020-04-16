using System;
using System.Collections.Generic;

namespace NewBackend.Models
{
    public  class Author
    {

        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}

    //     public Authors()
    //     {
    //         Books = new HashSet<Books>();
    //     }
        // public Authors(long id, string name, string surname)
        // {
        //     this.IdAuthor = id;
        //     this.Name = name;
        //     this.Surname = surname;
        // }
        // public virtual ICollection<Books> Books { get; set; }