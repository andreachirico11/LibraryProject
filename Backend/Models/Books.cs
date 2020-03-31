using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Books
    {
        public Books()
        {
            Loans = new HashSet<Loans>();
            UserFavourites = new HashSet<UserFavourites>();
        }

        public long IdBook { get; set; }
        public string Title { get; set; }
        public string Editor { get; set; }
        public long? PublishingYear { get; set; }
        public long IdGenre { get; set; }
        public long IdAuthor { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }

        public virtual Authors IdAuthorNavigation { get; set; }
        public virtual Genres IdGenreNavigation { get; set; }
        public virtual ICollection<Loans> Loans { get; set; }
        public virtual ICollection<UserFavourites> UserFavourites { get; set; }


        public Books(BookDTO newBook, long idGen, long idAuth) 
        {
            this.IdBook = newBook.IdBook;
            this.Title = newBook.Title;
            this.Editor = newBook.Editor;
            this.PublishingYear = newBook.PublishingYear;
            this.IdGenre = idGen;
            this.IdAuthor = idAuth;
            this.Description = newBook.Description;
            this.Isbn = newBook.Isbn;
        }
    }
}
