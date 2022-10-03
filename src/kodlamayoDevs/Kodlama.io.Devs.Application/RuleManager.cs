using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Exceptions;

namespace Kodlama.io.Devs.Application
{
    public class RuleManager
    {
        public void CheckWithAnyRule<TException>(Func<bool> operation) where TException : BusinessException, new()
        {
            if (!operation.Invoke())
                throw new TException();
        }

        public async Task CheckWithAnyRuleAsync<TException>(Func<Task<bool>> operation) where TException : BusinessException, new()
        {
            if (!await operation.Invoke())
                throw new TException();
        }

        public void CheckIfExists<TException>(Func<object?> operation) where TException : NotFoundException, new()
        {
            if (operation.Invoke() == null)
                throw new TException();
        }

        public async Task CheckIfExistsAsync<TException>(Func<Task<object?>> operation) where TException : NotFoundException, new()
        {
            if (await operation.Invoke() == null)
                throw new TException();
        }

        public void CheckIfAlreadyExists<TException>(Func<object?> operation) where TException : BadRequestException, new()
        {
            if (operation.Invoke() != null)
                throw new TException();
        }


        public async Task CheckIfAlreadyExistsAsync<TException>(Func<Task<object?>> operation) where TException : BadRequestException, new()
        {
            if (await operation.Invoke() != null)
                throw new TException();
        }
    }
}
