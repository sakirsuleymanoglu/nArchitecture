using Core.CrossCuttingConcerns.Exceptions;

namespace Kodlama.io.Devs.Application.Exceptions.Developers
{
    public class DeveloperNotFoundException : NotFoundException
    {
        public DeveloperNotFoundException(string? message = null) : base(message ?? "developer not found")
        {
        }
    }
}
