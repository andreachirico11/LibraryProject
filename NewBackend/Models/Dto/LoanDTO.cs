using System;
using NewBackend.Models;
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

    public LoanDTO(Loan loan)
    {
        DateStart = loan.DateStart;
        DateReturn = loan.DateReturn;
        IdUser = loan.UserId;
        IdBook = loan.BookId;
        BookTitle = loan.Book.Title;
        Isbn = loan.Book.Isbn;
        if (loan.User != null)
        {
            UserName = loan.User.Name + " " + loan.User.Surname;
        }
    }

}