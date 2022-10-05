using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommandRequest : IRequest<CreateOperationClaimCommandResponse>
    {
        public string Name { get; set; }
    }
}
