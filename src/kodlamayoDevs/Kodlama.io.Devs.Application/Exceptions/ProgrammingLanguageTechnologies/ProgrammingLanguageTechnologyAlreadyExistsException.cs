using Core.CrossCuttingConcerns.Enumerations;
using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.ProgrammingLanguageTechnologies
{
    public class ProgrammingLanguageTechnologyAlreadyExistsException : BusinessException
    {
        public ProgrammingLanguageTechnologyAlreadyExistsException() : base("Programming language technology already exists", BusinessExceptionTypes.BadRequest)
        {

        }
    }
}
