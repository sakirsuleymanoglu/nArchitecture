using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologiesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageTechnologyQueryRequest request = new() { PageRequest = pageRequest };
            GetListProgrammingLanguageTechnologyQueryResponse response = await SendRequestAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetByIdProgrammingLanguageTechnologyQueryRequest request = new() { Id = id };
            GetByIdProgrammingLanguageTechnologyQueryResponse response = await SendRequestAsync(request);
            return Ok(response);
        }

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
