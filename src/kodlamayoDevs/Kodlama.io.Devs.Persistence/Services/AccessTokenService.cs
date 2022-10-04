using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services;
using Kodlama.io.Devs.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Persistence.Services
{
    public class AccessTokenService : IAccessTokenService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        public AccessTokenService(ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
        {
            _tokenHelper = tokenHelper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<AccessToken> CreateAsync(User user)
        {
            IEnumerable<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListWithoutPaginateAsync(x => x.UserId == user.Id, tracking: false, include: x => x.Include(x => x.OperationClaim));

            List<OperationClaim> operationClaims = userOperationClaims.Select(x => new OperationClaim { Id = x.OperationClaimId, Name = x.OperationClaim.Name }).ToList();

            return _tokenHelper.CreateToken(user, operationClaims);
        }
    }
}
