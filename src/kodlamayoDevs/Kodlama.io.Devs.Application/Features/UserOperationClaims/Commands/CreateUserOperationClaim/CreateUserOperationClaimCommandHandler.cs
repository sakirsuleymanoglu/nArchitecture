using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Exceptions.OperationClaims;
using Kodlama.io.Devs.Application.Exceptions.UserOperationClaims;
using Kodlama.io.Devs.Application.Exceptions.Users;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim
{
    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommandRequest, CreateUserOperationClaimCommandResponse>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly RuleManager _ruleManager;

        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, RuleManager ruleManager, IAppUserRepository appUserRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
            _ruleManager = ruleManager;
            _appUserRepository = appUserRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<CreateUserOperationClaimCommandResponse> Handle(CreateUserOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            await _ruleManager.CheckIfExistsAsync<UserNotFoundException>(operation: async () => await _appUserRepository.GetAsync(x => x.Id == request.UserId, tracking: false));

            await _ruleManager.CheckIfExistsAsync<OperationClaimNotFoundException>(operation: async () => await _operationClaimRepository.GetAsync(x => x.Id == request.OperationClaimId, tracking: false));

            await _ruleManager.CheckIfAlreadyExistsAsync<UserOperationClaimAlreadyExistsException>(operation: async () => await _userOperationClaimRepository.GetAsync(x => x.UserId == request.UserId && x.OperationClaimId == request.OperationClaimId, tracking: false));

            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);

            UserOperationClaim createdUserOperationClaim = await _userOperationClaimRepository.AddAsync(userOperationClaim);

            return _mapper.Map<CreateUserOperationClaimCommandResponse>(createdUserOperationClaim);
        }
    }
}
