using System;
using System.Collections.Generic;

namespace NewBackend.Models
{
    public partial class Book
    {
        public Book()
        {
            FavouritesUserBooks = new HashSet<FavouritesUserBooks>();
        }

        public Book(int idBook, string title, string editor, int? publishingYear, string description, string isbn, int idGenre, int idAuthor)
        {
            IdBook = idBook;
            Title = title;
            Editor = editor;
            PublishingYear = publishingYear;
            Description = description;
            Isbn = isbn;
            IdGenre = idGenre;
            IdAuthor = idAuthor;
        }

        public int IdBook { get; set; }
        public string Title { get; set; }
        public string Editor { get; set; }
        public int? PublishingYear { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public int IdGenre { get; set; }
        public int IdAuthor { get; set; }


        public virtual ICollection<FavouritesUserBooks> FavouritesUserBooks { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Author Author { get; set; }
        public virtual Loan Loan { get; set; }
    }
}