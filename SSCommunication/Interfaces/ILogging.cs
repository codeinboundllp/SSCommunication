using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static SSCommunication.Enum;

namespace SSCommunication.Interfaces
{
    public interface ILogging
    {
        void Log(LogType type, string message, object? data = null, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null);
    }
}
