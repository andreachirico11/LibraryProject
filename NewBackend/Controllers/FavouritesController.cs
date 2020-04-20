using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserFavouritesController : ControllerBase
    {
        
        
        
    }
}
    
        // https://localhost:5001/api/userFavourites/add
        // [HttpPost("add")]
        // public async Task<int> AddBookToUserFavourites(BookAndUserIds bookAndUser)
        // {
        //     return await this.unitOfWork.AddBookToUserFavourites(bookAndUser);
        // }

        // [HttpPost("remove")]
        // public async Task<int> RemoveBookToUserFavourites(BookAndUserIds bookAndUser)
        // {
        //     return await this.unitOfWork.RemoveBookToUserFavourites(bookAndUser);

        // }