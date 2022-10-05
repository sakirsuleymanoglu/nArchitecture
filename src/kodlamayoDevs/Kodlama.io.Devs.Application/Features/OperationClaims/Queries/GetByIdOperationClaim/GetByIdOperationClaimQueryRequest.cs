using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQueryRequest : IRequest<GetByIdOperationClaimQueryResponse>
    {
        public int Id { get; set; }
    }
}