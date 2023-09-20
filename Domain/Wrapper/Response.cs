using System.Net;

namespace Domain;
public class Response<T>
{
    public int StatusCode { get; set; }
    public string Messege { get; set; }
    public T Data { get; set; }
    public Response(T data)=>Data=data;
    public Response(HttpStatusCode code) => StatusCode = (int)code;
    public Response(HttpStatusCode code,string message,T data)
    {
        StatusCode = (int)code;
        Messege = message;
        Data = data;
    }
    public Response(HttpStatusCode code, string message)
    {
        StatusCode = (int)code;
        Messege = message;
    }
}
