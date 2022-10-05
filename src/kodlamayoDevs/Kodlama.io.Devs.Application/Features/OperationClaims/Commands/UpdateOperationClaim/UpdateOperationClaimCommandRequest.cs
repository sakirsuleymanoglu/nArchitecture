using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}