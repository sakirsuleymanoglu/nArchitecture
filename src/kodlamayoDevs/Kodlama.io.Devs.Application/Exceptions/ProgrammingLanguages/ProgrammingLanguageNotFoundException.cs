using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages
{
    public class ProgrammingLanguageNotFoundException : NotFoundException
    {
        public ProgrammingLanguageNotFoundException(string? message = null) : base(message ?? "Programming language not found")
        {

        }
    }
}
