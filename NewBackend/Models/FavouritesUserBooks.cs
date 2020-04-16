using System.Collections.Generic;

namespace NewBackend.Models
{
    public partial class FavouritesUserBooks
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }

    }
}