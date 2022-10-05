using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommandRequest : IRequest<CreateOperationClaimCommandResponse>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => new[] { "CreateOperationClaim" };
    }
}
