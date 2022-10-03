namespace Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages
{
    public class ProgrammingLanguageAlreadyExistsException : BadRequestException
    {
        public ProgrammingLanguageAlreadyExistsException() : base("Programming language already exists")
        {

        }
    }
}
