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

        public long IdAuthor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
