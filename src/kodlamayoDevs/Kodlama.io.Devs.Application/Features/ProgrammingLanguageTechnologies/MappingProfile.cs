using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProgrammingLanguageTechnologyCommandRequest, ProgrammingLanguageTechnology>();
            CreateMap<ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologyCommandResponse>();
        }
    }
}
