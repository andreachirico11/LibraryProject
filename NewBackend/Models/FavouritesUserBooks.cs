using System.Collections.Generic;

namespace NewBackend.Models
{
    public partial class FavouritesUserBooks
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }

    }
}