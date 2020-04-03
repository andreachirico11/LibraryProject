using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface IBorrowRepository
    {
        DBLibraryContext context { get; set; }
        Task<bool> DiscoverIfBookIsBorrowed(long idBook);
        Task<bool> BorrowBook(BookAndUserIds bookAndUser);
        Task<List<LoanDTO>> GetAllLoansByUserId(long idUser);
        Task<bool> DeleteLoan(long idBook);
    }
}