using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;

namespace Maticsoft.Common
{
    /// <summary>        
    /// Description: EventLog class to write event log.
    /// Create Date: 2009-05-15
    /// Author:      JPL & Rock
    /// </summary>
    internal class EventLog : AbstractLog
    {
        public override void WriteEntry(string message, LogLevels logLevel)
        {
            AddLog("", "", message, GetLogType(logLevel));
        }

        public override void WriteEntry(string message, Exception ex, LogLevels logLevel)
        {
            AddLog(GetAppInfo(), ex.Source, message + Environment.NewLine + GetCustomErrStr(ex), GetLogType(logLevel));
        }

        private void AddLog(string appInfo, string source, string message, EventLogEntryType eventType)
        {
            StringBuilder sbMessage = new StringBuilder();
            String strMessage = String.Empty;

            sbMessage.AppendLine("Log Message");
            sbMessage.AppendLine("---------------------------------");

            if (!string.IsNullOrEmpty(message))
            {
                sbMessage.AppendLine("Message:");
                sbMessage.AppendLine(message);
            }
            if (!string.IsNullOrEmpty(source))
            {
                sbMessage.AppendLine("Source:");
                sbMessage.AppendLine(source);
            }
            if (!string.IsNullOrEmpty(appInfo))
            {
                sbMessage.AppendLine("Application Environment Information:");
                sbMessage.AppendLine("----------------------------------");
                sbMessage.AppendLine(appInfo);
            }

            strMessage = sbMessage.ToString();

            string sSource = GetEventSource();
            EnsureEventSource(sSource);
            System.Diagnostics.EventLog.WriteEntry(sSource, strMessage, eventType);
        }

        private string GetEventSource()
        {
            try
            {
                return ConfigurationManager.AppSettings.Get("EventSource");
            }
            catch   //Config file can't find,using default EventSource
            {
                if (Application.ProductName.Equals(string.Empty))
                {
                    return "CCBA.LOG";
                }
                else
                {
                    return Application.ProductName;
                }
            }
        }

        private void EnsureEventSource(string eventSource)
        {
            if (!System.Diagnostics.EventLog.SourceExists(eventSource))
            {
                System.Diagnostics.EventLog.CreateEventSource(eventSource, "Application");
                System.Diagnostics.EventLog.WriteEntry(eventSource, "EventSource '" + eventSource
                    + "' created on " + DateTime.Now.ToString(), EventLogEntryType.Information);
            }
        }

        private EventLogEntryType GetLogType(LogLevels logLevel)
        {
            switch (logLevel)
            {
                case LogLevels.DEBUG_LOG:
                case LogLevels.INFO_LOG:
                    return EventLogEntryType.Information;
                case LogLevels.WARN_LOG:
                    return EventLogEntryType.Warning;
                case LogLevels.ERROR_LOG:
                    return EventLogEntryType.Error;
                default:
                    return EventLogEntryType.Information;
            }
        }
    }
}
