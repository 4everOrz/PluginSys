using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common
{
    /// <summary>        
    /// Description: Interface to define common behavior.
    /// </summary>
    internal interface ILog
    {
        void WriteEntry(string message, LogLevels logLevel);
        void WriteEntry(string message, Exception ex, LogLevels logLevel);
    }
}
