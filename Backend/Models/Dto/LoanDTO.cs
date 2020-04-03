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

    public LoanDTO() { }

    public LoanDTO(DateTime dateStart, long idUser, long idBook, string bookTitle, string isbn)
    {
        DateStart = dateStart;
        IdUser = idUser;
        BookTitle = bookTitle;
        Isbn = isbn;
        IdBook = idBook;
    }
}