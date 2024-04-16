using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Data;
using TodoApi.Model.Request;
using TodoApi.Service;
namespace TodoApi.Controllers
{
    [ApiController]
    [Route("/api/authentication/")]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
        [HttpPost("register")]
        public IActionResult Register(UserRegisterDto registerRequestDto, UserManager<Users> userManager)
        {
            var user = new Users
            {
                Email = registerRequestDto.Email,
                UserName = registerRequestDto.Email,
                Fullname = registerRequestDto.Fullname,
                DateOfBirth = registerRequestDto.DateOfBirth
            };
            var result = userManager.CreateAsync(user, registerRequestDto.Password).Result;
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginRequestDto,[FromServices]IAuthManager authManager)
        {
            try
            {
                var response = await authManager.login(loginRequestDto);
                return Ok(response);
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
        }
       


    }
}