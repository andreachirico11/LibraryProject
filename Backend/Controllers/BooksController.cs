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
    public class BooksController: ControllerBase
    {
        public IUnitOfWork unitOfWork { get; set; }
        public BooksController(IUnitOfWork uow) 
        {
            this.unitOfWork = uow;
        }

        [HttpGet]
        public async Task<List<BookDTO>> GetAllBooks()
        {
            return await unitOfWork.GetAllBooks();
        }

        [HttpGet("{id}")]
        public async Task<BookDTO> GetBookById(long id)
        {
             return await unitOfWork.GetBookById(id);
        }

        [HttpPost]
        public async Task<bool> PostBook(BookDTO newBook)
        {
            return await unitOfWork.InsertBook(newBook);
        }





        [HttpPut("{id}")]
        public async Task<int> UpdateBook(Books newBook, long id)
        {
            if(id != newBook.IdBook) {
                BadRequest();
            }
            // return await unitOfWork.UpdateBook(newBook);
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteBook(long id) 
        {
            // return await unitOfWork.DeleteBook(id);
            throw new NotImplementedException();
        }
    }
}