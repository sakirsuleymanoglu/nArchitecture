using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.Developers
{
    public class DeveloperPhoneNumberAlreadyExistsException : BadRequestException
    {
        public DeveloperPhoneNumberAlreadyExistsException(string? message = null) : base(message ?? "developer phone number already exists")
        {
        }
    }
}
