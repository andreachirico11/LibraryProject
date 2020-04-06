using System;
using Backend.Models;
public class LoanDTO
{
    public DateTime DateStart { get; set; }
    public DateTime? DateReturn { get; set; }
    public long IdUser { get; set; }
    public long IdBook { get; set; }
    public string? BookTitle { get; set; }
    public string? Isbn { get; set; }
    public string? UserName { get; set; }

    public LoanDTO() { }

    public LoanDTO(DateTime dateStart, long idUser, long idBook, string bookTitle, string isbn)
    {
        DateStart = dateStart;
        IdUser = idUser;
        BookTitle = bookTitle;
        Isbn = isbn;
        IdBook = idBook;
    }
    public LoanDTO(Loans loan)
    {
        DateStart = loan.DateStart;
        DateReturn = loan.DateReturn;
        IdUser = loan.IdUser;
        IdBook = loan.IdBook;
        BookTitle = loan.IdBookNavigation.Title;
        Isbn = loan.IdBookNavigation.Isbn;
        UserName = loan.IdUserNavigation.Name + " " + loan.IdUserNavigation.Surname;
    }
}