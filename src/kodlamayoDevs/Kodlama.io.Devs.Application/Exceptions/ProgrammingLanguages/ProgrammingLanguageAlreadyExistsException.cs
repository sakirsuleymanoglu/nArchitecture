using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages
{
    public class ProgrammingLanguageAlreadyExistsException : BusinessException
    {
        public ProgrammingLanguageAlreadyExistsException() : base("Programming language already exists", BusinessExceptionTypes.BadRequest)
        {

        }
    }
}
