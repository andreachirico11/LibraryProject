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
        IUnitOfWork unitOfWork = new EfUnitOfWork();

        [HttpGet]
        public Task<List<Books>> GetAllBooks()
        {
            return unitOfWork.GetAllBooks();
        }
    }
}