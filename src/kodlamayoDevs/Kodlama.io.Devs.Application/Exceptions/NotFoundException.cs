using Core.CrossCuttingConcerns.Enumerations;
using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException(string message) : base(message, BusinessExceptionTypes.NotFound)
        {

        }
    }
}
