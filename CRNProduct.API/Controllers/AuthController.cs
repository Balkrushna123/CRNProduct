using Asp.Versioning;
using CRNProduct.Application.Interfaces;
using CRNProduct.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRNProduct.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwtService;

        public AuthController(IUnitOfWork unitOfWork, JwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _unitOfWork.Users.GetByUserNameAsync(request.UserName);

            if (user == null || user.Password != request.Password)
            {
                return Unauthorized("Invalid Username or Password");
            }

            var token = _jwtService.GenerateToken(user.UserName);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _unitOfWork.SaveChangesAsync();

            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
        {
            var user = await _unitOfWork.Users.GetByUserNameAsync(request.UserName);

            if (user == null)
            {
                return Unauthorized("Invalid User");
            }

            if (user.RefreshToken != request.RefreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return Unauthorized("Invalid or Expired Refresh Token");
            }

            var token = _jwtService.GenerateToken(user.UserName);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

            await _unitOfWork.SaveChangesAsync();

            return Ok(token);
        }
    }
}