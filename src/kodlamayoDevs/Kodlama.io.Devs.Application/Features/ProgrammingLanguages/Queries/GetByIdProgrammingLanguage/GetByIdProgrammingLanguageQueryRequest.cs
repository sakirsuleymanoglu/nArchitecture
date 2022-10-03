using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQueryRequest : IRequest<GetByIdProgrammingLanguageQueryResponse>
    {
        public int Id { get; set; }
    }
}
