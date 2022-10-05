namespace Kodlama.io.Devs.Application.Exceptions.Authentications
{
    public class IncorrectLoginException : BadRequestException
    {
        public IncorrectLoginException() : base("email or password incorrect")
        {

        }

        public IncorrectLoginException(string message) : base(message)
        {

        }
    }
}
