using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommandRequest : IRequest, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "DeleteOperationClaim" };
    }
}
