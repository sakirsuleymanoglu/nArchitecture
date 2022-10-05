using Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.CreateDeveloperGithub;
using Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.DeleteDeveloperGithub;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperGithubsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateDeveloperGithubCommandRequest request)
        {
            CreateDeveloperGithubCommandResponse response = await SendRequestAsync(request);
            return Created("", response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteDeveloperGithubCommandRequest request = new() { Id = id };
            await SendRequestAsync(request);
            return NoContent();
        }
    }
}
