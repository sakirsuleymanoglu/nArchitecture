using Core.CrossCuttingConcerns.Enumerations;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class BadRequestException : BusinessException
    {
        public BadRequestException(string message) : base(message, BusinessExceptionTypes.BadRequest)
        {

        }
    }
}
