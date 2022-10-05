using Core.Application.Requests;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQueryRequest : IRequest<GetListOperationClaimQueryResponse>
    {
        public PageRequest PageRequest { get; set; }
    }
}