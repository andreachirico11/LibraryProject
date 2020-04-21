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


















