using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? IpAddress { get; set; }
    }
}
