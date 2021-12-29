using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Models
{
    public class EmailTemplate
    {
        public string Subject { get; set; }
        public string FromEmail { get; set; }
        public List<string> ToEmail { get; set; }
        public string FromName { get; set; }
        public DateTime? CustomDate { get; set; }
        public List<CustomEmailTemplateFields> Fields { get; set; }
    }
}
