using System;
using System.Collections.Generic;

namespace NewBackend.Models
{
    public partial class Book
    {
        public Book () 
        {
             UserThatLike = new HashSet<FavouritesUserBooks>();
        }
        public int IdBook { get; set; }
        public string Title { get; set; }
        public string Editor { get; set; }
        public int? PublishingYear { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }



        public virtual ICollection<FavouritesUserBooks> UserThatLike { get; set; }
    }
}