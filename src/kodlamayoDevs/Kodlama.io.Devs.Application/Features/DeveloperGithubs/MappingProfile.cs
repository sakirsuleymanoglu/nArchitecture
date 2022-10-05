using AutoMapper;
using Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.CreateDeveloperGithub;
using Kodlama.io.Devs.Application.Features.DeveloperGithubs.Commands.UpdateDeveloperGithub;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.DeveloperGithubs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateDeveloperGithubCommandRequest, DeveloperGithub>().ForMember(x => x.Id, x => x.MapFrom(x => x.DeveloperId));
            CreateMap<DeveloperGithub, CreateDeveloperGithubCommandResponse>();
            CreateMap<UpdateDeveloperGithubCommandRequest, DeveloperGithub>();
        }
    }
}
