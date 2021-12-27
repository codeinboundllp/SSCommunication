using System.Net;
using static SSCommunication.Enum;

namespace SSCommunication.Models
{
    public class EmailServiceResponse<T>
    {
        public HttpStatusCode Status { get; set; }
        public T Response { get; set; }
        public ErrorResponse? Error { get; set; }
    }
}
