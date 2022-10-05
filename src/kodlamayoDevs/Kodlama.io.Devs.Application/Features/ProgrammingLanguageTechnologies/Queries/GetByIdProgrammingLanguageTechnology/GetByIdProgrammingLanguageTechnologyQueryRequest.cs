using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology
{
    public class GetByIdProgrammingLanguageTechnologyQueryRequest : IRequest<GetByIdProgrammingLanguageTechnologyQueryResponse>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { "GetByIdProgrammingLanguageTechnology" };
    }
}
