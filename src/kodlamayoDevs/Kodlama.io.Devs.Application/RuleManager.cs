using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Exceptions;

namespace Kodlama.io.Devs.Application
{
    public class RuleManager
    {
        private object? CreateException(Type type, string? message = null) => Activator.CreateInstance(type, message != null ? new object[] { message } : null);

        public void CheckWithAnyRule<TException>(Func<bool> operation, string? message = null) where TException : BusinessException, new()
        {
            object? exception = CreateException(typeof(TException), message);

            if (!operation.Invoke())
                throw exception != null ? (TException)exception : new TException();
        }

        public async Task CheckWithAnyRuleAsync<TException>(Func<Task<bool>> operation, string? message = null) where TException : BusinessException, new()
        {
            object? exception = CreateException(typeof(TException), message);

            if (!await operation.Invoke())
                throw exception != null ? (TException)exception : new TException();
        }

        public void CheckIfExists<TException>(Func<object?> operation, string? message = null) where TException : NotFoundException, new()
        {
            object? exception = CreateException(typeof(TException), message);

            if (operation.Invoke() == null)
                throw exception != null ? (TException)exception : new TException();
        }

        public async Task CheckIfExistsAsync<TException>(Func<Task<object?>> operation, string? message = null) where TException : NotFoundException, new()
        {
            object? exception = CreateException(typeof(TException), message);

            if (await operation.Invoke() == null)
                throw exception != null ? (TException)exception : new TException();
        }

        public void CheckIfAlreadyExists<TException>(Func<object?> operation, string? message = null) where TException : BadRequestException, new()
        {
            object? exception = CreateException(typeof(TException), message);

            if (operation.Invoke() != null)
                throw exception != null ? (TException)exception : new TException();
        }


        public async Task CheckIfAlreadyExistsAsync<TException>(Func<Task<object?>> operation, string? message = null) where TException : BadRequestException, new()
        {
            object? exception = CreateException(typeof(TException), message);

            if (await operation.Invoke() != null)
                throw exception != null ? (TException)exception : new TException();
        }
    }
}
