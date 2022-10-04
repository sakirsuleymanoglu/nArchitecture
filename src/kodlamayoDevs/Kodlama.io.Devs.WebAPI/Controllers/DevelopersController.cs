using Core.Security.Entities;
using Kodlama.io.Devs.Application.Features.Developers.Commands.CreateDeveloper;
using Kodlama.io.Devs.Application.Features.Developers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(DeveloperCreateModel model)
        {
            CreateDeveloperCommandRequest request = new()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                IpAddress = GetIpAddress(),
            };

            CreateDeveloperCommandResponse response = await SendRequestAsync(request);
            SetRefreshTokenToCookie(response.RefreshToken);
            return Created("", response.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
