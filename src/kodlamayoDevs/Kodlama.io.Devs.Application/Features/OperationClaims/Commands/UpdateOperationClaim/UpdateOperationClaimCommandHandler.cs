using AutoMapper;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Exceptions.OperationClaims;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommandRequest>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;
        private readonly RuleManager _ruleManager;
        public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, RuleManager ruleManager)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
            _ruleManager = ruleManager;
        }

        public async Task<Unit> Handle(UpdateOperationClaimCommandRequest request, CancellationToken cancellationToken)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == request.Id, tracking: false);


            _ruleManager.CheckIfExists<OperationClaimNotFoundException>(operation: () => operationClaim);

            await _ruleManager.CheckIfAlreadyExistsAsync<OperationClaimAlreadyExistsException>(operation: async () =>
            {
                if (request.Name != operationClaim!.Name)
                    return await _operationClaimRepository.GetAsync(x => x.Name == request.Name, tracking: false);
                return null;
            });

            _mapper.Map(request, operationClaim);

            await _operationClaimRepository.UpdateAsync(operationClaim!);

            return Unit.Value;
        }
    }
}
