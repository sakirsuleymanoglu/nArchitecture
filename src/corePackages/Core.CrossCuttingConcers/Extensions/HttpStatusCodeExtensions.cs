using System.Net;

namespace Core.CrossCuttingConcerns.Extensions
{
    public static class HttpStatusCodeExtensions
    {
        public static int ConvertToInt(this HttpStatusCode httpStatusCode) => (int)httpStatusCode;
    }
}
