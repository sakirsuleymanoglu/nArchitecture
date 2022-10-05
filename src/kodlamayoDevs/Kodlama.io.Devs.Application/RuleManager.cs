using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Exceptions;

namespace Kodlama.io.Devs.Application
{
    public class RuleManager
    {
        private TException CreateException<TException>(Type type, string? message = null) where TException : BusinessException
        {
            object? exception = Activator.CreateInstance(type, new object[] { message });

            if (exception == null)
                throw new NullReferenceException("exception has a null reference");

            return (TException)exception;
        }

        public void CheckWithAnyRule<TException>(Func<bool> operation, string? message = null) where TException : BusinessException
        {
            if (!operation.Invoke())
                throw CreateException<TException>(typeof(TException), message);
        }

        public async Task CheckWithAnyRuleAsync<TException>(Func<Task<bool>> operation, string? message = null) where TException : BusinessException
        {
            if (!await operation.Invoke())
                throw CreateException<TException>(typeof(TException), message);
        }

        public void CheckIfExists<TException>(Func<object?> operation, string? message = null) where TException : NotFoundException
        {
            if (operation.Invoke() == null)
                throw CreateException<TException>(typeof(TException), message);
        }

        public async Task CheckIfExistsAsync<TException>(Func<Task<object?>> operation, string? message = null) where TException : NotFoundException
        {
            if (await operation.Invoke() == null)
                throw CreateException<TException>(typeof(TException), message);
        }

        public void CheckIfAlreadyExists<TException>(Func<object?> operation, string? message = null) where TException : BadRequestException
        {
            if (operation.Invoke() != null)
                throw CreateException<TException>(typeof(TException), message);
        }


        public async Task CheckIfAlreadyExistsAsync<TException>(Func<Task<object?>> operation, string? message = null) where TException : BadRequestException
        {
            if (await operation.Invoke() != null)
                throw CreateException<TException>(typeof(TException), message);
        }
    }
}
