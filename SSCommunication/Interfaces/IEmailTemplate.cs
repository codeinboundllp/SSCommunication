using SSCommunication.Models;
using System;
using System.Collections.Generic;

namespace SSCommunication.Interfaces
{
    public interface IEmailTemplate
    {
        public string Subject { get; set; }
        public string FromEmail { get; set; }
        public List<string> ToEmail { get; set; }
        public string FromName { get; set; }
        public DateTime? CustomDate { get; set; }
        public List<CustomEmailTemplateFields> Fields { get; set; }
    }
}
