using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class UserFavourites
    {
        public UserFavourites() {}
        public UserFavourites(long idF, long idB, long idU)
        {
            this.IdFav = idF;
            this.IdBook = idB;
            this.IdUser = idU;
        }

        public long IdFav { get; set; }
        public long IdUser { get; set; }
        public long IdBook { get; set; }

        public virtual Books IdBookNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }

        
    }
    

}