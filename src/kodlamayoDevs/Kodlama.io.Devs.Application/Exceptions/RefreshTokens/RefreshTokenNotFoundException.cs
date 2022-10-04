namespace Kodlama.io.Devs.Application.Exceptions.RefreshTokens
{
    public class RefreshTokenNotFoundException : NotFoundException
    {
        public RefreshTokenNotFoundException() : base("refresh token not found")
        {

        }
    }
}
