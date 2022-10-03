using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology
{
    public class GetByIdProgrammingLanguageTechnologyQueryRequest : IRequest<GetByIdProgrammingLanguageTechnologyQueryResponse>
    {
        public int Id { get; set; }
    }
}
