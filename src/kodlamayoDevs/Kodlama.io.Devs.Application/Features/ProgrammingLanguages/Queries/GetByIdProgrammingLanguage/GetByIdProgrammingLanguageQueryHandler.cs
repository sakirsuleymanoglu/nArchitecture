using AutoMapper;
using Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQueryRequest, GetByIdProgrammingLanguageQueryResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;
        private readonly RuleManager _ruleManager;
        public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, RuleManager ruleManager)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
            _ruleManager = ruleManager;
        }
        public async Task<GetByIdProgrammingLanguageQueryResponse> Handle(GetByIdProgrammingLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id, enableTracking: false);

            _ruleManager.CheckIfExists<ProgrammingLanguageNotFoundException>(operation: () => programmingLanguage);

            return _mapper.Map<GetByIdProgrammingLanguageQueryResponse>(programmingLanguage);
        }
    }
}
