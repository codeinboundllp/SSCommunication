using static SSCommunication.Enum;

namespace SSCommunication.Models
{
    public class EmailServiceResponse
    {
        public EmailSendingStatus Status { get; set; }
        public ErrorResponse? Error { get; set; }
    }
}
