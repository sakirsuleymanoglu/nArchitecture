using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQueryRequest : IRequest<GetListOperationClaimQueryResponse>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles => new[] { "GetListOperationClaim" };
    }
}