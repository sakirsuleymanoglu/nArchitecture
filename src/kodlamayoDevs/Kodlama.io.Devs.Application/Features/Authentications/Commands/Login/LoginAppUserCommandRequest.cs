using Core.Security.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Authentications.Commands.Login
{
    public class LoginAppUserCommandRequest : UserForLoginDto, IRequest<LoginAppUserCommandResponse>
    {
    }
}
