using System.Net;

namespace ElearningApplication.Exceptions;
public class ForbiddenException : Exception
{
    public HttpStatusCode Status { get; private set; } = HttpStatusCode.Forbidden;

    public ForbiddenException(string message) : base(message)
    {

    }
}