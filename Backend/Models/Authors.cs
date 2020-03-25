using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Authors
    {
        public Authors()
        {
            Books = new HashSet<Books>();
        }
        public Authors(long id, string name, string surname)
        {
            this.IdAuthor = id;
            this.Name = name;
            this.Surname = surname;
        }

        public long IdAuthor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
