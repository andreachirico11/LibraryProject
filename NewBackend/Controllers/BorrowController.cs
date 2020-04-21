using System;
using System.Collections.Generic;
using System.Linq;
using NewBackend.Models;
using NewBackend;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowController : ControllerBase
    {
        public BorrowController(NewBackendDbContext ctx)
        {
            this.ctx = ctx;
        }

        public NewBackendDbContext ctx { get; set; }


        [HttpGet]
        public async Task<List<LoanDTO>> GetAllLoans()
        {
            return await ctx.Loans
                            .Include(l => l.Book)
                            .Include(l => l.User)
                            .Select(l => new LoanDTO(l))
                            .ToListAsync();
        }

        [HttpGet("{idUser}")]
        public async Task<List<LoanDTO>> GetAllLoansByUserId(int idUser)
        {
            return await ctx.Loans
                            .Where(l => l.UserId == idUser)
                            .Where(l => l.DateReturn == null)
                            .Include(l => l.Book)
                            .Select(l => new LoanDTO(l))
                            .ToListAsync();
        }


        [HttpPost]
        public async Task<int> BorrowBook(BookAndUserIds bookAndUser)
        {
            var isAlreadyLoaned = await ctx.Loans
                                            .Where(l => l.UserId == bookAndUser.idUser && l.BookId == bookAndUser.idBook && l.DateReturn == null)
                                            .SingleOrDefaultAsync();

            if (isAlreadyLoaned == null)
            {
                var actualDate = DateTime.Now;
                ctx.Loans.Add(new Loan(0, actualDate, bookAndUser.idBook, bookAndUser.idUser));
                return await ctx.SaveChangesAsync();

            }
            return 0;
        }


        [HttpDelete("{idBook}")]
        public async Task<bool> DeleteLoanByBookId(int idBook)
        {
            var loanToUpdate = await ctx.Loans.Where(l => l.BookId == idBook && l.DateReturn == null ).SingleOrDefaultAsync();
            loanToUpdate.DateReturn = DateTime.Now; 
            return await ctx.SaveChangesAsync() > 0 ? true : false;
        }
    }
}












