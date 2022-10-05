using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}
