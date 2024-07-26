using System.Text.Json.Serialization;

namespace Monix.Core.Responses;

public class Response<T>
{
    private readonly int _code;

    public Response()
    {
    }

    public Response(T? data, int code = Configuration.DefaultStatusCode, string? message = null)
    {
        _code = code;
        Data = data;
        Message = message;
    }

    public T? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
}