using System;
using System.Collections.Generic;

namespace NewBackend.Models
{
    public partial class User
    {
        public User () 
        {
             FavouritesUserBooks = new HashSet<FavouritesUserBooks>();
        }

        public User(string email, string password, int isAdmin, string name, string surname, int idUser, string address, string phone, string imgPath)
        {
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            Name = name;
            Surname = surname;
            IdUser = idUser;
            Address = address;
            Phone = phone;
            ImgPath = imgPath;
        }
        public User(UserDTO newUser)
        {
            Email = newUser.Email;
            Password = newUser.Password;
            IsAdmin = 0;
            Name = newUser.Name;
            Surname = newUser.Surname;
            IdUser = 0;
            Address = newUser.Address;
            Phone = newUser.Phone;
            ImgPath = newUser.ImgPath;
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
        // public ICollection<int> Favourites { get; set;}


        public virtual ICollection<FavouritesUserBooks> FavouritesUserBooks { get; set; }
        public virtual Loan Loan { get; set; }
    }
}