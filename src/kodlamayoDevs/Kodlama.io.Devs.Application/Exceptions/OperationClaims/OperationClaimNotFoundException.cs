namespace Kodlama.io.Devs.Application.Exceptions.OperationClaims
{
    public class OperationClaimNotFoundException : NotFoundException
    {
        public OperationClaimNotFoundException() : base("operation claim not found")
        {

        }
    }
}
