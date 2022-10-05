namespace Kodlama.io.Devs.Application.Exceptions.OperationClaims
{
    public class OperationClaimNotFoundException : NotFoundException
    {
        public OperationClaimNotFoundException(string? message = null) : base(message ?? "operation claim not found")
        {

        }
    }
}
