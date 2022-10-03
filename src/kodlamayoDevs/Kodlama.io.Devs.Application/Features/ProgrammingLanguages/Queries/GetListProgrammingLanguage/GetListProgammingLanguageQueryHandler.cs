using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQueryRequest, GetListProgrammingLanguageQueryResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetListProgammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<GetListProgrammingLanguageQueryResponse> Handle(GetListProgrammingLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            return _mapper.Map<GetListProgrammingLanguageQueryResponse>(programmingLanguages);
        }
    }
}
