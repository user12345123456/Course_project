using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZakazObedov1.DataAccess;
using ZakazObedov1.Entities;
using ZakazObedov1.Services.Contract;
using ZakzObedov1.ZakazDto;

namespace ZakazObedov1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        //public readonly ZakazObedov1DBContext _zakazobedov1Context;
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
         public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            return await _userService.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] UserDto user)
        {
            return await _userService.Create(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            return await _userService.GetById(id);
        }
        [HttpPut]
        public async Task<ActionResult<int>> Update([FromBody] UserDto user)
        {
            return await _userService.Update(user);
        }

       /* [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            var user = await _zakazobedov1Context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            _zakazobedov1Context.Users.Remove(user);
            await _zakazobedov1Context.SaveChangesAsync();
            return Ok();
        }
       */

    }
}