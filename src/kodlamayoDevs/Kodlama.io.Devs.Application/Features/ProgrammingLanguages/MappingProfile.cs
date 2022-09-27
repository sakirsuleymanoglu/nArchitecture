using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommandResponse>();
            CreateMap<CreateProgrammingLanguageCommandRequest, ProgrammingLanguage>();
            CreateMap<UpdateProgrammingLanguageCommandRequest, ProgrammingLanguage>();
        }
    }
}
