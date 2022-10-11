using Core.Application;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Exceptions.UserOperationClaims;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommandRequest>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly RuleManager _ruleManager;
        public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, RuleManager ruleManager)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _ruleManager = ruleManager;
        }

        public async Task<Unit> Handle(DeleteUserOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(x => x.Id == request.Id, tracking: false);

            _ruleManager.CheckIfExists<UserOperationClaimNotFoundException>(operation: () => userOperationClaim);

            await _userOperationClaimRepository.DeleteAsync(userOperationClaim!);

            return Unit.Value;
        }
    }
}
