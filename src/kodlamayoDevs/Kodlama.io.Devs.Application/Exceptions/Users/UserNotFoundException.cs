namespace Kodlama.io.Devs.Application.Exceptions.Users
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException() : base("user not found")
        {

        }
    }
}
