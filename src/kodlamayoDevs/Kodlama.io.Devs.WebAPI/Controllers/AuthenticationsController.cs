using Kodlama.io.Devs.Application.Features.Authentications.Commands.Login;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            LoginCommandResponse response = await SendRequestAsync(request);
            return Ok(response);
        }
    }
}
