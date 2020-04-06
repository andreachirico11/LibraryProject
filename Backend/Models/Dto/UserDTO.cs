using System.Collections.Generic;
using Backend.Models;
public class UserDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public long IdUser { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? ImgPath { get; set; }
    public ICollection<Loans>? Loans { get; set; }
    public ICollection<BookDTO>? Favourites { get; set; }

    public UserDTO() { }

    public UserDTO(Users user, List<BookDTO> usFav)
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
        this.Loans = user.Loans;
        this.Favourites = usFav;

    }
    public UserDTO(Users user)
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
    }
}
