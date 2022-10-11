using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.UserOperationClaims
{
    public class UserOperationClaimNotFoundException : NotFoundException
    {
        public UserOperationClaimNotFoundException(string? message = null) : base(message ?? "user operation claim not found")
        {
        }
    }
}
