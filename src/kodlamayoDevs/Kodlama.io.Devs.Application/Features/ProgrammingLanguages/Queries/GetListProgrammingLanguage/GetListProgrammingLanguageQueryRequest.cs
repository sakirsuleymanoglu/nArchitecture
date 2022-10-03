using Core.Application.Requests;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQueryRequest : IRequest<GetListProgrammingLanguageQueryResponse>
    {
        public PageRequest PageRequest { get; set; }
    }
}
