using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}