using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListByUserUserOperationClaim;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetListByUser(int userId, [FromQuery] PageRequest pageRequest)
        {
            GetListByUserUserOperationClaimQueryRequest request = new() { UserId = userId, PageRequest = pageRequest };
            GetListByUserUserOperationClaimQueryResponse response = await SendRequestAsync(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserOperationClaimCommandRequest request)
        {
            CreateUserOperationClaimCommandResponse response = await SendRequestAsync(request);
            return Created("", response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteUserOperationClaimCommandRequest request = new() { Id = id };
            await SendRequestAsync(request);
            return NoContent();
        }
    }
}
