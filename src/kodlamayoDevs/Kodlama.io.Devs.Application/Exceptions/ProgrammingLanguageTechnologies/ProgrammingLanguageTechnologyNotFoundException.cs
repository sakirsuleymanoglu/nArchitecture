using Core.CrossCuttingConcerns.Enumerations;
using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguageTechnologies
{
    public class ProgrammingLanguageTechnologyNotFoundException : BusinessException
    {
        public ProgrammingLanguageTechnologyNotFoundException() : base("Programming language technology not found", BusinessExceptionTypes.NotFound)
        {

        }
    }
}
