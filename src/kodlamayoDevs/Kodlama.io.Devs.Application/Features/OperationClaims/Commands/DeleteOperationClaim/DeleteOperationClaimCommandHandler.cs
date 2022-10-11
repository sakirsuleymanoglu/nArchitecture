using Core.Application;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Exceptions.OperationClaims;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommandRequest>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly RuleManager _ruleManager;
        public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, RuleManager ruleManager)
        {
            _operationClaimRepository = operationClaimRepository;
            _ruleManager = ruleManager;
        }

        public async Task<Unit> Handle(DeleteOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id, tracking: false);

            _ruleManager.CheckIfExists<OperationClaimNotFoundException>(operation: () => operationClaim);

            await _operationClaimRepository.DeleteAsync(operationClaim!);

            return Unit.Value;
        }
    }
}
