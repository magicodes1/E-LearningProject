using System.Text.Json;
using ElearningApplication.Models.Error;

namespace ElearningApplication.Models.Response;

public class DataResponse
{
    public bool Status { get; set; }
    public object Data { get; set; }

    public ErrorDetail Error { get; set; }



    public DataResponse(bool status, object data, ErrorDetail error)
    {
        Status = status;
        Data = data;
        Error = error;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}