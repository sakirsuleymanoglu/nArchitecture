using Core.Security.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommandRequest : UserForRegisterDto, IRequest<CreateDeveloperCommandResponse>
    {

    }
}
