namespace SSCommunication
{
    public class Enum
    {
        public enum EmailSendingStatus
        {
            Sent,
            Sending,
            Error,
            Pending,
            Unknown
        }
        public enum EmailTemplateTag
        {
            Anchor,
            Div,
            Table,
            Span,
            Img
        }
        public enum SSLType
        {
            SSL,
            TSL,
            STARTTLS
        }
        public enum LogType
        {
            Success,
            Exception,
            Failed,
            Others
        }
    }
}
