namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology
{
    public class GetByIdProgrammingLanguageTechnologyQueryResponse
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string ProgrammingLanguage { get; set; }
        public string Name { get; set; }
    }
}