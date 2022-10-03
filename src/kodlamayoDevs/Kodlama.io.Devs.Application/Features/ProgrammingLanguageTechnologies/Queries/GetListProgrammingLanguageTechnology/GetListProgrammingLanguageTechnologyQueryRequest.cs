using Core.Application.Requests;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnology
{
    public class GetListProgrammingLanguageTechnologyQueryRequest : IRequest<GetListProgrammingLanguageTechnologyQueryResponse>
    {
        public PageRequest PageRequest { get; set; }
    }
}
