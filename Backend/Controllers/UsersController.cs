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
    public class UsersController : ControllerBase
    {
        public IUnitOfWork unitOfWork { get; set; }
        public UsersController(IUnitOfWork uow)
        {
            this.unitOfWork = uow;
        }
        [HttpPost("auth")]
        public async Task<UserDTO> AuthorizeUser(Credentials credentials) 
        {
            return await unitOfWork.FindUserByCredentials(credentials);
        }
        [HttpGet("{id}")]
        public async Task<UserDTO> GetuserById(long id)
        {
            return await unitOfWork.GetUserById(id);
        }
        [HttpGet]
        public async Task<List<UserDTO>> GetAllUsers()
        {
            return await unitOfWork.GetAllUsers();
        }
    }
}
