using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Models;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowController : ControllerBase
    {
        public IUnitOfWork unitOfWork { get; set; }
        public BorrowController(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        [HttpPost]
        public async Task<bool> BorrowBook(BookAndUserIds bookAndUser)
        {
            return await this.unitOfWork.BorrowBook(bookAndUser);
        }

        [HttpGet("{idUser}")]
        public async Task<List<LoanDTO>> GetAllLoansByUserId(long idUser )
        {
            return await this.unitOfWork.GetAllLoansByUserId(idUser);
        }

        [HttpDelete("{idBook}")]
        public async Task<bool> DeleteLoanByBookId(long idBook)
        {
            return await this.unitOfWork.DeleteLoan(idBook);
        }

        [HttpGet]
        public async Task<List<LoanDTO>> GetAllLoans()
        {
            return await this.unitOfWork.GetAllLoans();
        }
    }
}