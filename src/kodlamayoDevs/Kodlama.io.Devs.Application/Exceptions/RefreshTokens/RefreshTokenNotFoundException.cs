using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.RefreshTokens
{
    public class RefreshTokenNotFoundException : NotFoundException
    {
        public RefreshTokenNotFoundException(string? message = null) : base(message ?? "refresh token not found")
        {

        }
    }
}
