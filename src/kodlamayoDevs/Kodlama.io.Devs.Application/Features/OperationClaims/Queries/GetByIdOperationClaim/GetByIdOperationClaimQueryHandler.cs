using AutoMapper;
using Core.Application;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Exceptions.OperationClaims;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQueryRequest, GetByIdOperationClaimQueryResponse>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly RuleManager _ruleManager;
        private readonly IMapper _mapper;
        public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, RuleManager ruleManager, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _ruleManager = ruleManager;
            _mapper = mapper;
        }

        public async Task<GetByIdOperationClaimQueryResponse> Handle(GetByIdOperationClaimQueryRequest request, CancellationToken cancellationToken)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id, tracking: false);

            _ruleManager.CheckIfExists<OperationClaimNotFoundException>(operation: () => operationClaim);

            return _mapper.Map<GetByIdOperationClaimQueryResponse>(operationClaim);
        }
    }
}
