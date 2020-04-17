using System;
using System.Collections.Generic;

namespace NewBackend.Models
{
    public class Author
    {

        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public Author(int idAuthor, string name, string surname)
        {
            IdAuthor = idAuthor;
            Name = name;
            Surname = surname;
        }

        public virtual ICollection<Book> Books { get; set; }
    }
}

// public Authors(long id, string name, string surname)
// {
//     this.IdAuthor = id;
//     this.Name = name;
//     this.Surname = surname;
// }