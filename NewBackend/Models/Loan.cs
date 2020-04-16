using System;
using System.Collections.Generic;

namespace NewBackend.Models
{
    public partial class Loan
    {
        public int IdLoan { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateReturn { get; set; }
    }
}



        // public long IdUser { get; set; }
        // public long IdBook { get; set; }

        // public virtual Books IdBookNavigation { get; set; }
        // public virtual Users IdUserNavigation { get; set; }