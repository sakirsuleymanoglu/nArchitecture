namespace Kodlama.io.Devs.Application.Exceptions.Users
{
    public class UserEmailAlreadyExistsException : BadRequestException
    {
        public UserEmailAlreadyExistsException() : base("User email already exists")
        {

        }
    }
}
