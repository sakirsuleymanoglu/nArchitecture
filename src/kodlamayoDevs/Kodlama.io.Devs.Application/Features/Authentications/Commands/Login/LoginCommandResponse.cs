using Core.Security.Entities;
using Core.Security.JWT;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.Login
{
    public class LoginCommandResponse
    {
        public AccessToken AcessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
