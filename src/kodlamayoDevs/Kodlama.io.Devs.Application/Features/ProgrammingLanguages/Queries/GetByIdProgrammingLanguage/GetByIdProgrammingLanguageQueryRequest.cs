using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQueryRequest : IRequest<GetByIdProgrammingLanguageQueryResponse>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "GetByIdProgrammingLanguage" };
    }
}
