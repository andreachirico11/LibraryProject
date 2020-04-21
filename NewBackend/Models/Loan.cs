using System;
using System.Collections.Generic;

namespace NewBackend.Models
{
    public partial class Loan
    {
        public Loan(int idLoan, DateTime dateStart, int bookId, int userId)
        {
            IdLoan = idLoan;
            DateStart = dateStart;
            BookId = bookId;
            UserId = userId;
        }

        public Loan(int idLoan, DateTime dateStart, int bookId, int userId, DateTime dateReturn)
        {
            IdLoan = idLoan;
            DateStart = dateStart;
            DateReturn = dateReturn;
            BookId = bookId;
            UserId = userId;
        }

        public int IdLoan { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateReturn { get; set; }
        public int BookId { get; set; } 
        public int UserId { get; set; }


        public  Book Book { get; set; }
        public  User User { get; set; }
    }
}
