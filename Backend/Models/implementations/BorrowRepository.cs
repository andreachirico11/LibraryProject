using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class BorrowRepository : IBorrowRepository
    {

        public BorrowRepository(DBLibraryContext context)
        {
            // BookRepo = bookRepo;
            this.context = context;
        }

        public DBLibraryContext context { get; set; }
        // public IBooksRepository BookRepo { get; set; }


        public async Task<bool> DiscoverIfBookIsBorrowed(long idBook)
        {
            var foundBook = await this.context.Loans.Where(l => l.IdBook == idBook).FirstOrDefaultAsync();
            return foundBook != null ? true : false;
        }
        public async Task<long> getMaxId()
        {
            return await this.context.Loans
                                .OrderByDescending(l => l.IdLoan)
                                .Select(l => l.IdLoan)
                                .FirstOrDefaultAsync();
        }

        public async Task<bool> BorrowBook(BookAndUserIds bookAndUser)
        {
            var id = await this.getMaxId() + 1;
            var date = DateTime.Now;
            System.Console.WriteLine(date);
            var newLoan = new Loans(id, date, bookAndUser.idUser, bookAndUser.idBook);
            context.Loans.Add(newLoan);
            var result = await context.SaveChangesAsync();
            return result == 1 ? true : false;
        }

        public async Task<List<LoanDTO>> GetAllLoansByUserId(long idUser)
        {
            List<LoanDTO> listOfLoansDTO = new List<LoanDTO>();
            var loans = await this.context.Loans
                                    .Where(l => l.IdUser == idUser)
                                    .Where(l => l.DateReturn == null)
                                    .Include(l => l.IdBookNavigation)
                                    .ToListAsync();

            foreach (var loan in loans)
            {
                var LoanDTO = new LoanDTO(
                    loan.DateStart,
                    loan.IdUser,
                    loan.IdBook,
                    loan.IdBookNavigation.Title,
                    loan.IdBookNavigation.Isbn
                );
                listOfLoansDTO.Add(LoanDTO);
            }


            return listOfLoansDTO;
        }

        public async Task<bool> DeleteLoan(long idBook)
        {
            var loanToRemove = await this.context.Loans.Where( l => l.IdBook == idBook).FirstOrDefaultAsync();

            loanToRemove.DateReturn = DateTime.Now;

            this.context.Update(loanToRemove);


            // this.context.Loans.Remove(loanToRemove);
            await context.SaveChangesAsync();
            return true;
            
        }

    }
}