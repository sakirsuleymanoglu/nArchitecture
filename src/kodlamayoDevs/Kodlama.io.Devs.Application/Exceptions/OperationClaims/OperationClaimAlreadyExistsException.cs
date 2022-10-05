namespace Kodlama.io.Devs.Application.Exceptions.OperationClaims
{
    public class OperationClaimAlreadyExistsException : BadRequestException
    {
        public OperationClaimAlreadyExistsException() : base("operation claim already exists")
        {

        }
    }
}
