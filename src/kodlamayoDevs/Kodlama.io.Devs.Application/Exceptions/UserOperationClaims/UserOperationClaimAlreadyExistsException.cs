using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.UserOperationClaims
{
    public class UserOperationClaimAlreadyExistsException : BadRequestException
    {
        public UserOperationClaimAlreadyExistsException(string? message = null) : base(message ?? "user operation claim already exists")
        {
        }
    }
}
