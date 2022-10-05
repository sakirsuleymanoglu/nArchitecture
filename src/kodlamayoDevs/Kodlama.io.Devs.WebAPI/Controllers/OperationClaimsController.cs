using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQueryRequest request = new() { PageRequest = pageRequest };
            GetListOperationClaimQueryResponse response = await SendRequestAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetByIdOperationClaimQueryRequest request = new() { Id = id };
            GetByIdOperationClaimQueryResponse response = await SendRequestAsync(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOperationClaimCommandRequest request)
        {
            CreateOperationClaimCommandResponse response = await SendRequestAsync(request);
            return Created("", response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteOperationClaimCommandRequest request = new() { Id = id };
            await SendRequestAsync(request);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOperationClaimCommandRequest request)
        {
            await SendRequestAsync(request);
            return NoContent();
        }
    }
}
