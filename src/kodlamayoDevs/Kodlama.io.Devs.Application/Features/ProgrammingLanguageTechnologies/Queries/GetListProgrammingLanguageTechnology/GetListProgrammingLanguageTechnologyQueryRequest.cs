using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology
{
    public class GetListProgrammingLanguageTechnologyQueryRequest : IRequest<GetListProgrammingLanguageTechnologyQueryResponse>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles => new[] { "GetListProgrammingLanguageTechnologyQuery" };
    }
}
