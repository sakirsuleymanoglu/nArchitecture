using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Queries.GetListByUserUserOperationClaim
{
    public class GetListByUserUserOperationClaimQueryHandler : IRequestHandler<GetListByUserUserOperationClaimQueryRequest, GetListByUserUserOperationClaimQueryResponse>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;
        public GetListByUserUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }
        public async Task<GetListByUserUserOperationClaimQueryResponse> Handle(GetListByUserUserOperationClaimQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(x => x.UserId == request.UserId,
                index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                include: x => x.Include(x => x.User).Include(x => x.OperationClaim),
                tracking: false);

            return _mapper.Map<GetListByUserUserOperationClaimQueryResponse>(userOperationClaims);
        }
    }
}
