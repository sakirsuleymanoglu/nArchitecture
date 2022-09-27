using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProgrammingLanguageTechnologyCommandRequest request)
        {
            CreateProgrammingLanguageTechnologyCommandResponse response = await SendRequestAsync(request);
            return Created("", response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteProgrammingLanguageTechnologyCommandRequest request = new() { Id = id };
            await SendRequestAsync(request);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProgrammingLanguageTechnologyCommandRequest request)
        {
            await SendRequestAsync(request);
            return NoContent();
        }
    }
}
