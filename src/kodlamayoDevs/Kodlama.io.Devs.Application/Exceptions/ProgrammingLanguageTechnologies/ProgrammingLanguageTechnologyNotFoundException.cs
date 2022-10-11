using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguageTechnologies
{
    public class ProgrammingLanguageTechnologyNotFoundException : NotFoundException
    {
        public ProgrammingLanguageTechnologyNotFoundException(string? message = null) : base(message ?? "Programming language technology not found")
        {

        }
    }
}
