namespace Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguageTechnologies
{
    public class ProgrammingLanguageTechnologyAlreadyExistsException : BadRequestException
    {
        public ProgrammingLanguageTechnologyAlreadyExistsException() : base("Programming language technology already exists")
        {

        }
    }
}
