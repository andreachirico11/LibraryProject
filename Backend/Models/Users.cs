using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Users
    {
        public Users()
        {
            Loans = new HashSet<Loans>();
            Favourites = new HashSet<UserFavourites>();
        }
        public string Email { get; set; }
        public string? Password { get; set; }
        public long? IsAdmin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public long IdUser { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? ImgPath { get; set; }

        public virtual ICollection<Loans>? Loans { get; set; }
        public virtual ICollection<UserFavourites>? Favourites  { get; set; }
    }
}
