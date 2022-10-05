using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommandRequest>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<Unit> Handle(DeleteUserOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetAsync(x => x.Id == request.Id, tracking: false);

            await _userOperationClaimRepository.DeleteAsync(userOperationClaim!);

            return Unit.Value;
        }
    }
}
