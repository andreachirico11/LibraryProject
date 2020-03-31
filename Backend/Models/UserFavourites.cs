using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class UserFavourites
    {
        public long IdFav { get; set; }
        public long IdUser { get; set; }
        public long IdBook { get; set; }

        public virtual Books IdBookNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}