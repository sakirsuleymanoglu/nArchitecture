using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQueryRequest : IRequest<GetByIdOperationClaimQueryResponse>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "GetByIdOperationClaim" };
    }
}