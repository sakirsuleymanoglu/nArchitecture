using AutoMapper;
using Core.Application;
using Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguageTechnologies;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology
{
    public class GetByIdProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetByIdProgrammingLanguageTechnologyQueryRequest, GetByIdProgrammingLanguageTechnologyQueryResponse>
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
        private readonly IMapper _mapper;
        private readonly RuleManager _ruleManager;
        public GetByIdProgrammingLanguageTechnologyQueryHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, RuleManager ruleManager)
        {
            _mapper = mapper;
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            _ruleManager = ruleManager;
        }

        public async Task<GetByIdProgrammingLanguageTechnologyQueryResponse> Handle(GetByIdProgrammingLanguageTechnologyQueryRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id, tracking: false, include: x => x.Include(x => x.ProgrammingLanguage));

            _ruleManager.CheckIfExists<ProgrammingLanguageTechnologyNotFoundException>(operation: () => programmingLanguageTechnology);

            return _mapper.Map<GetByIdProgrammingLanguageTechnologyQueryResponse>(programmingLanguageTechnology);
        }
    }
}
