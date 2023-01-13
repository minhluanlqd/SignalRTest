using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _authContext;
        public UserController(UserContext authContext) 
        {
            _authContext = authContext;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authentication([FromBody] UserLogin userObj)
        {
            if (userObj == null)
            {
                return BadRequest("User is NULL");
            }

            // user exists
            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.Password == userObj.Password);
            if (user == null)
            {
                return NotFound(new {Message = "User Not Found!"});
            }
            return Ok(new {Message = "Login Successfully"});
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserAuth userObj)
        {
            if (userObj == null)
            {
                return BadRequest("User is NULL");
            }

            await _authContext.Users.AddAsync(userObj);
            await  _authContext.SaveChangesAsync();
            return Ok("User Registered Successfully");
        }

    }
}
