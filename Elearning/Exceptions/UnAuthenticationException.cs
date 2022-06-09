using System.Net;

namespace ElearningApplication.Exceptions;
public class UnAuthenticationException : Exception
{
    public HttpStatusCode Status { get; private set; } = HttpStatusCode.Unauthorized;
    public UnAuthenticationException(string message) : base(message)
    {

    }
}