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
                            // .Include(l => l.User)
                            .Select(l => new LoanDTO(l))
                            .ToListAsync();
        }
    }
}














// [HttpPost]
// public async Task<bool> BorrowBook(BookAndUserIds bookAndUser)
// {
//     return await this.unitOfWork.BorrowBook(bookAndUser);
// }

// [HttpDelete("{idBook}")]
// public async Task<bool> DeleteLoanByBookId(long idBook)
// {
//     return await this.unitOfWork.DeleteLoan(idBook);
// }