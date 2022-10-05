namespace Kodlama.io.Devs.Application.Exceptions.Authentications
{
    public class IncorrectLoginException : BadRequestException
    {
        public IncorrectLoginException(string? message = null) : base(message ?? "user email or password incorrect")
        {

        }
    }
}
