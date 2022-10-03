using Core.CrossCuttingConcerns.Enumerations;
using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions
{
    public class BadRequestException : BusinessException
    {
        public BadRequestException(string message) : base(message, BusinessExceptionTypes.BadRequest)
        {

        }
    }
}
