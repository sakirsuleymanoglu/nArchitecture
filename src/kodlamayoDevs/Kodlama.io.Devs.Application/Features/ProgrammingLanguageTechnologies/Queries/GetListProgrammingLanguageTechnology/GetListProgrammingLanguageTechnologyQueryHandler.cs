using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology
{
    public class GetListProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologyQueryRequest, GetListProgrammingLanguageTechnologyQueryResponse>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        public GetListProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<GetListProgrammingLanguageTechnologyQueryResponse> Handle(GetListProgrammingLanguageTechnologyQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguageTechnology> programmingLanguageTechnologies = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, include: x => x.Include(x => x.ProgrammingLanguage));

            return _mapper.Map<GetListProgrammingLanguageTechnologyQueryResponse>(programmingLanguageTechnologies);
        }
    }
}
