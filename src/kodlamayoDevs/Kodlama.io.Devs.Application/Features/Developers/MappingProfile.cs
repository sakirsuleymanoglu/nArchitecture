using AutoMapper;
using Kodlama.io.Devs.Application.Features.Developers.Commands.CreateDeveloper;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Developers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, CreateDeveloperCommandResponse>();
        }
    }
}
