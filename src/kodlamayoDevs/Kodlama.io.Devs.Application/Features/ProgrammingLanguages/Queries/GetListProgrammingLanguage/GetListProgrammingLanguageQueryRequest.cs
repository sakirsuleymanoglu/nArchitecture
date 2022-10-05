using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQueryRequest : IRequest<GetListProgrammingLanguageQueryResponse>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles => new[] { "GetListProgrammingLanguage" };
    }
}
