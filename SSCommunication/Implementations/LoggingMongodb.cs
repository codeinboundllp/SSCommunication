using SSCommunication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SSCommunication.Implementations
{
    public class LoggingMongodb : ILogging
    {
        public void Log(Enum.LogType type, string message, object data = null, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            try
            {

            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
