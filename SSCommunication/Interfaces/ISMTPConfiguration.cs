using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SSCommunication.Enum;

namespace SSCommunication.Interfaces
{
    public interface ISMTPConfiguration
    {
        /// <summary>
        /// Add Host Address like email.secureserver.net
        /// </summary>
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsSSLEnabled { get; set; }
        public SSLType SSL { get; set; }
        public int TimeOut { get; set; }
    }
}
