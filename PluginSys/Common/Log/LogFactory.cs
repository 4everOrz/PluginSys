using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Common
{
    /// <summary>        
    /// Description: LogFactory class to create correct instance according configuration.
    /// Create Date: 2009-05-15
    /// Author:      JPL 
    /// </summary>
    internal class LogFactory
    {
        private static LogFactory _instance;
        protected LogFactory()
        { }

        public static LogFactory GetFactory()
        {
            if (_instance == null)
                _instance = new LogFactory();
            return _instance;
        }

        internal ILog GetLogInstance(string logType)
        {
            try
            {
                ILog logInstance = null;
                LogType lType = LogType.FileLog;

                try
                {
                    lType = (LogType)Enum.Parse(typeof(LogType), logType, true);
                }
                catch
                {
                    throw;
                }

                switch (lType)
                {
                    case LogType.EventLog:
                        logInstance = new EventLog();
                        break;
                    case LogType.FileLog:
                        logInstance = new FileLog();
                        break;
                }
                return logInstance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
