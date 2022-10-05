namespace Kodlama.io.Devs.Application.Exceptions.Users
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string? message = null) : base(message ?? "User not found")
        {

        }
    }
}
