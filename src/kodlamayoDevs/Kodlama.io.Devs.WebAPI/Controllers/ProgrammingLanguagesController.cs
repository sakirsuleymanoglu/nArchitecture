using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProgrammingLanguageCommandRequest request)
        {
            CreateProgrammingLanguageCommandResponse response = await SendRequestAsync(request);
            return Created("", response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteProgrammingLanguageCommandRequest request = new() { Id = id };
            await SendRequestAsync(request);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProgrammingLanguageCommandRequest request)
        {
            await SendRequestAsync(request);
            return NoContent();
        }
    }
}
