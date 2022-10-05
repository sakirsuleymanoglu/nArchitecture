namespace Kodlama.io.Devs.Application.Exceptions.Users
{
    public class UserEmailAlreadyExistsException : BadRequestException
    {
        public UserEmailAlreadyExistsException(string? message = null) : base(message ?? "User email already exists")
        {

        }
    }
}
