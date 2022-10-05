using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProgrammingLanguageTechnologyCommandRequest, ProgrammingLanguageTechnology>();
            CreateMap<ProgrammingLanguageTechnology, CreateProgrammingLanguageTechnologyCommandResponse>();
            CreateMap<ProgrammingLanguageTechnology, GetListProgrammingLanguageTechnologyElementModel>().ForMember(x => x.ProgrammingLanguageName, x => x.MapFrom(x => x.ProgrammingLanguage.Name));
            CreateMap<IPaginate<ProgrammingLanguageTechnology>, GetListProgrammingLanguageTechnologyQueryResponse>();
            CreateMap<ProgrammingLanguageTechnology, GetByIdProgrammingLanguageTechnologyQueryResponse>().ForMember(x => x.ProgrammingLanguage, x => x.MapFrom(x => x.ProgrammingLanguage.Name));
        }
    }
}
