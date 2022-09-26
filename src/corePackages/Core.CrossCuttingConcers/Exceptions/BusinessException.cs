namespace Core.CrossCuttingConcerns.Exceptions;

public class BusinessException : Exception
{
    public BusinessExceptionTypes BusinessExceptionType { get; }
    public BusinessException(string message, BusinessExceptionTypes businessExceptionType) : base(message)
    {
        BusinessExceptionType = businessExceptionType;
    }
}

public enum BusinessExceptionTypes
{
    BadRequest,
    NotFound
}