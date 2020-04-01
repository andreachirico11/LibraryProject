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
    public class UserFavouritesController : ControllerBase
    {
        // https://localhost:5001/api/userFavourites/add
        public IUnitOfWork unitOfWork { get; set; }
        public UserFavouritesController(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }

        [HttpPost("add")]
        public async Task<int> AddBookToUserFavourites(BookAndUserIds bookAndUser)
        {
            return await this.unitOfWork.AddBookToUserFavourites(bookAndUser);
        }
    }
}