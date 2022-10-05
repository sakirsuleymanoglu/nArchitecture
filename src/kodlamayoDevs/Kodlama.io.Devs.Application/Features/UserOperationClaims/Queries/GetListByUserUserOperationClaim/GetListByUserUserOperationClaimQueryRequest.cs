using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListByUserUserOperationClaim
{
    public class GetListByUserUserOperationClaimQueryRequest : IRequest<GetListByUserUserOperationClaimQueryResponse>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public int UserId { get; set; }

        public string[] Roles => new[] { "GetListByUserUserOperationClaim" };
    }
}
