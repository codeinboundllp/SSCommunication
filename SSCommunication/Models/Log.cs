using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SSCommunication.Enum;

namespace SSCommunication.Models
{
    public class Log
    {
        public string LogId { get; set; }
        public DateTime DateOfLog { get; set; }
        public object? Data { get; set; }
        public int LineNumber { get; set; }
        public string Caller { get; set; }
        public string Message { get; set; }
        public LogType Type { get; set; }
    }
}
