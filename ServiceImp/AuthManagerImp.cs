
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TodoApi.Data;
using TodoApi.Model.Request;
using TodoApi.Model.Response;
using TodoApi.Service;

namespace TodoApi.ServiceImp
{
    public class AuthManagerImp : IAuthManager
    {
        private readonly UserManager<Users> _userManager;
        private readonly IConfiguration _jwtConfig;
        public AuthManagerImp(UserManager<Users> userManager, IConfiguration jwtConfig)
        {
            _userManager = userManager;
            _jwtConfig = jwtConfig;
        }

       
        public Task<AuthResponseDto> login(UserLoginDto loginRequestDto)
        {
            var result = _userManager.FindByEmailAsync(loginRequestDto.Email).Result;
            if (result == null)
            {
                throw new UnauthorizedAccessException();
            }
            return GenerateJwtToken(loginRequestDto).ContinueWith(task =>
            {
                var response = new AuthResponseDto
                {
                    Token = task.Result,
                };
                return response;
            });
        }
        public Task<string> GenerateJwtToken(UserLoginDto user)
        {
            var security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig["Jwt:Key"]));
            var credentials = new SigningCredentials(security, SecurityAlgorithms.HmacSha256);
            var roles = _userManager.GetRolesAsync(_userManager.FindByEmailAsync(user.Email).Result).Result;
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));
            var userClaims = _userManager.GetClaimsAsync(_userManager.FindByEmailAsync(user.Email).Result).Result;
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Email),
            }.Union(roleClaims).Union(userClaims);
            var token = new JwtSecurityToken(
                _jwtConfig["Jwt:Issuer"],
                _jwtConfig["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
        
    }

 
}