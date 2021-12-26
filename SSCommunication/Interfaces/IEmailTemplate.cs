using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Interfaces
{
    public interface IEmailTemplate
    {
        public string Subject { get; set; }
        public string FromEmail { get; set; }
        public List<string> ToEmail { get; set; }
        public string FromName { get; set; }
        public DateTime? CustomDate { get; set; }
    }
}
