namespace Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages
{
    public class ProgrammingLanguageAlreadyExistsException : BadRequestException
    {
        public ProgrammingLanguageAlreadyExistsException(string? message = null) : base(message ?? "Programming language already exists")
        {

        }
    }
}
