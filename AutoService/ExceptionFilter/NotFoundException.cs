using System.Net;

namespace AutoService.ExceptionFilter
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string message) : base(HttpStatusCode.NotFound, message)
        {
        }
    }
}
