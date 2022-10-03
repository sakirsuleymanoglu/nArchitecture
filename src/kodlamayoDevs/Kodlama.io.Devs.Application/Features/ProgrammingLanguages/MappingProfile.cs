using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
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
            CreateMap<ProgrammingLanguage, GetListProgrammingLanguageElementModel>();
            CreateMap<Paginate<ProgrammingLanguage>, GetListProgrammingLanguageQueryResponse>();
            CreateMap<ProgrammingLanguage, GetByIdProgrammingLanguageQueryResponse>();
        }
    }
}
