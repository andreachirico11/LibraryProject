using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace NewBackend
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        public BooksController(NewBackendDbContext ctx)
        {
            this.ctx = ctx;
        }

        public NewBackendDbContext ctx { get; set; }


        [HttpGet]
        public async Task<List<BookDTO>> GetAllBooks()
        {
            return await ctx.Books
                        .Include(b => b.Author)
                        .Include(b => b.Genre)
                         .Include(b => b.Loan)
                         .Include(b => b.FavouritesUserBooks)
                         .Select(b => new BookDTO(b))
                        .ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<BookDTO> GetBookById(int id)
        {
            return await ctx.Books
                        .Where(b => b.IdBook == id)
                        .Include(b => b.Author)
                        .Include(b => b.Genre)
                        .Include(b => b.Loan)
                        .Include(b => b.FavouritesUserBooks)
                        .Select(b => new BookDTO(b))
                        .FirstOrDefaultAsync();
        }





    }
}














// public IUnitOfWork unitOfWork { get; set; }
// public BooksController(IUnitOfWork uow) 
// {
//     this.unitOfWork = uow;
// }


// [HttpPost]
// public async Task<bool> PostBook(BookDTO newBook)
// {
//     return await unitOfWork.InsertBook(newBook);
// }





// [HttpPut("{id}")]
// public async Task<int> UpdateBook(Books newBook, long id)
// {
//     if(id != newBook.IdBook) {
//         BadRequest();
//     }
//     // return await unitOfWork.UpdateBook(newBook);
//     throw new NotImplementedException();
// }

// [HttpDelete("{id}")]
// public async Task<int> DeleteBook(long id) 
// {
//     // return await unitOfWork.DeleteBook(id);
//     throw new NotImplementedException();
// }