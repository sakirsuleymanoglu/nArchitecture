using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Authentications.Commands.Login;
using Kodlama.io.Devs.Application.Features.Authentications.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            LoginCommandRequest request = new() { Email = model.Email, Password = model.Password, IpAddress = GetIpAddress() };
            LoginCommandResponse response = await SendRequestAsync(request);
            SetRefreshTokenToCookie(response.RefreshToken);
            return Ok(response.AcessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
