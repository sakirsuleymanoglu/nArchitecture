using AutoMapper;
using Core.Application;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Exceptions.OperationClaims;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommandRequest, CreateOperationClaimCommandResponse>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly RuleManager _ruleManager;

        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, RuleManager ruleManager)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _ruleManager = ruleManager;
        }

        public async Task<CreateOperationClaimCommandResponse> Handle(CreateOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            await _ruleManager.CheckIfAlreadyExistsAsync<OperationClaimAlreadyExistsException>(operation: async () => await _operationClaimRepository.GetAsync(x => x.Name == request.Name));

            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);

            OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(operationClaim);

            return _mapper.Map<CreateOperationClaimCommandResponse>(createdOperationClaim);
        }
    }
}
