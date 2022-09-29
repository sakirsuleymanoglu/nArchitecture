using Kodlama.io.Devs.Application.Features.Developers.Commands.CreateDeveloper;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateDeveloperCommandRequest request)
        {
            CreateDeveloperCommandResponse response = await SendRequestAsync(request);
            return Created("", response);
        }
    }
}
