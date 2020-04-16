using System;
using System.Collections.Generic;

namespace NewBackend.Models
{
    public partial class User
    {
        public User () 
        {
             FavouriteBooks = new HashSet<FavouritesUserBooks>();
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IsAdmin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public int IdUser { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? ImgPath { get; set; }
        public ICollection<int> Favourites { get; set;}


        public virtual ICollection<FavouritesUserBooks> FavouriteBooks { get; set; }
    }
}