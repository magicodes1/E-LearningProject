using System.Net;


namespace ElearningApplication.Exceptions;
public class NotFoundException : Exception
{
    public HttpStatusCode Status { get; private set; } = HttpStatusCode.NotFound;

    public NotFoundException(string msg) : base(msg)
    {

    }
}