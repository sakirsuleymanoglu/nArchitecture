using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.OperationClaims
{
    public class OperationClaimAlreadyExistsException : BadRequestException
    {
        public OperationClaimAlreadyExistsException(string? message = null) : base(message ?? "operation claim already exists")
        {

        }
    }
}
