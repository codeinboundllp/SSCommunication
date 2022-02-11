using SSCommunication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Models
{
    public class SMTPConfiguration : ISMTPConfiguration
    {
        public string Host { get ; set; }
        public int Port { get; set ; }
        public string UserName { get ; set; }
        public string Password { get; set ; }
        public bool IsSSLEnabled { get; set ; }
        public Enum.SSLType SSL { get; set; }
        /// <summary>
        /// Default Value 5000
        /// </summary>
        public int TimeOut { get; set; } = 5000;
    }
}
