using Backend.Models;
public class BookDTO {
        public long IdBook { get; set; }
        public string Title { get; set; }
        public string Editor { get; set; }
        public long? PublishingYear { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }

        public BookDTO() {}
        public BookDTO(Books book, Genres genre, Authors author) {
            this.IdBook = book.IdBook;
            this.Title = book.Title;
            this.Editor = book.Editor;
            this.PublishingYear = book.PublishingYear;
            this.Genre = genre.Name;
            this.Author = author.Name + " " + author.Surname;
            this.Description = book.Description;
            this.Isbn = book.Isbn;
        }
        public BookDTO(Books book) {
            this.IdBook = book.IdBook;
            this.Title = book.Title;
            this.Editor = book.Editor;
            this.PublishingYear = book.PublishingYear;
           
            // this.Author = author.Name + " " + author.Surname;
            this.Description = book.Description;
            this.Isbn = book.Isbn;
        }
}