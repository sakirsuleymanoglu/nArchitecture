using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQueryRequest request = new() { PageRequest = pageRequest };
            GetListProgrammingLanguageQueryResponse response = await SendRequestAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetByIdProgrammingLanguageQueryRequest request = new() { Id = id };
            GetByIdProgrammingLanguageQueryResponse response = await SendRequestAsync(request);
            return Ok(response);
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
