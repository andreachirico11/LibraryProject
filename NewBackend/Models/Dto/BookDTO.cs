using NewBackend.Models;
public class BookDTO
{
    public long IdBook { get; set; }
    public string Title { get; set; }
    public string Editor { get; set; }
    public long? PublishingYear { get; set; }
    public string? Genre { get; set; }
    public string? Author { get; set; }
    public string Description { get; set; }
    public string Isbn { get; set; }
    public bool? IsRented { get; set; }

    public BookDTO() { }

    public BookDTO(Book book)
    {
        IdBook = book.IdBook;
        Title = book.Title;
        Editor = book.Editor;
        PublishingYear = book.PublishingYear;
        Genre = book.Genre.Name;
        Author = book.Author.Name +' ' + book.Author.Surname;
        Description = book.Description;
        Isbn = book.Isbn;
        IsRented = this.VerifyIfIsRented(book);
    }


    private bool VerifyIfIsRented(Book book)
    {
        if (book.Loan != null)
        {
            if (book.Loan.DateReturn == null)
            {
                return  true;
            }
            else
            {
                return  false;
            }
        } else {
            return false;
        }

    }








    // public BookDTO(Books book, Genres genre, Authors author) {
    //     this.IdBook = book.IdBook;
    //     this.Title = book.Title;
    //     this.Editor = book.Editor;
    //     this.PublishingYear = book.PublishingYear;
    //     this.Genre = genre.Name;
    //     this.Author = author.Name + " " + author.Surname;
    //     this.Description = book.Description;
    //     this.Isbn = book.Isbn;
    // }
    // public BookDTO(Books book) {
    //     this.IdBook = book.IdBook;
    //     this.Title = book.Title;
    //     this.Editor = book.Editor;
    //     this.PublishingYear = book.PublishingYear;
    //     this.Description = book.Description;
    //     this.Isbn = book.Isbn;
    // }

}