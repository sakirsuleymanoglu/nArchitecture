namespace Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguageTechnologies
{
    public class ProgrammingLanguageTechnologyAlreadyExistsException : BadRequestException
    {
        public ProgrammingLanguageTechnologyAlreadyExistsException(string? message = null) : base(message ?? "Programming language technology already exists")
        {

        }
    }
}
