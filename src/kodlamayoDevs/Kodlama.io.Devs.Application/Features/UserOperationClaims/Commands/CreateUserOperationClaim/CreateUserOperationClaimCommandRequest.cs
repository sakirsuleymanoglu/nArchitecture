using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommandRequest : IRequest<CreateUserOperationClaimCommandResponse>
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}