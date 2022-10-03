namespace Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages
{
    public class ProgrammingLanguageNotFoundException : NotFoundException
    {
        public ProgrammingLanguageNotFoundException() : base("Programming language not found")
        {

        }
    }
}
