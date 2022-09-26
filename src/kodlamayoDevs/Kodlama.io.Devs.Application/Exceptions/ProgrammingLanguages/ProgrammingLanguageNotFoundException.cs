using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguages
{
    public class ProgrammingLanguageNotFoundException : BusinessException
    {
        public ProgrammingLanguageNotFoundException() : base("Programming language not found", BusinessExceptionTypes.NotFound)
        {

        }
    }
}
