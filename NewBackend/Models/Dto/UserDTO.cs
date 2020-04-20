using NewBackend.Models;
using System.Collections.Generic;
public class UserDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public int IdUser { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? ImgPath { get; set; }

     public List<Loan>? Loans { get; set; }
     public List<BookDTO>? Favourites { get; set; }

    public UserDTO() { }


    public UserDTO(User user)
    {
        this.Email = user.Email;
        this.Password = user.Password;
        this.IsAdmin = user.IsAdmin == 0 ? false : true;
        this.Name = user.Name;
        this.Surname = user.Surname;
        this.IdUser = user.IdUser;
        this.Address = user.Address;
        this.Phone = user.Phone;
        this.ImgPath = user.ImgPath;
        this.Favourites = new List<BookDTO>();
        if(user.FavouritesUserBooks != null) {
             
             foreach (var favB in user.FavouritesUserBooks)
            {
                Favourites.Add(new BookDTO(favB.Book));
            }   
        }
    }
}
