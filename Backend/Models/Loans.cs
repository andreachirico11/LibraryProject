using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Loans
    {
        public Loans()
        {
        }

        public Loans(long idLoan, DateTime dateStart, long idUser, long idBook)
        {
            IdLoan = idLoan;
            DateStart = dateStart;
            IdUser = idUser;
            IdBook = idBook;
        }

        public long IdLoan { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateReturn { get; set; }
        public long IdUser { get; set; }
        public long IdBook { get; set; }

        public virtual Books IdBookNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }

        
    }
}
