using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;

namespace Maticsoft.Common
{
    /// <summary>        
    /// Description: A class which used to provider log interface.
    /// Create Date: 2009-05-15
    /// Author:      JPL 
    /// </summary>
    public class LogManager  //consider to COM+ and cluster,need do action in methods.
    {
        /// <summary>
        /// Get Log Level
        /// </summary>
        /// <returns>Log level</returns>
        private static string GetLogLevel()
        {
            try
            {
                AppSettingsReader reader = new AppSettingsReader();
                return (string)reader.GetValue("LogLevel", typeof(String));
            }
            catch   //if RICOH.LOG.config file can't find,using default log level:Debug.
            {
                return LogLevels.DEBUG_LOG.ToString();
            }
        }

        /// <summary>
        /// Get Log Type
        /// </summary>
        /// <returns>Log type</returns>
        private static string GetLogType()
        {
            try
            {
                AppSettingsReader reader = new AppSettingsReader();
                return (string)reader.GetValue("LogType", typeof(String));
            }
            catch
            {
                return LogType.FileLog.ToString();
            }
        }

        /// <summary>
        /// Write debug message
        /// </summary>
        /// <param name="message">Debug message</param>
        public static void Debug(string message)
        {
            try
            {
                LogLevels logLevel = GetLogLevelsEnum();
                if (logLevel <= LogLevels.DEBUG_LOG)
                {
                    AddLog(message, LogLevels.DEBUG_LOG);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Write debug message and exception
        /// </summary>
        /// <param name="message">Debug message</param>
        /// <param name="ex">Debug exception</param>
        public static void Debug(string message, Exception ex)
        {
            try
            {
                LogLevels logLevel = GetLogLevelsEnum();
                if (logLevel <= LogLevels.DEBUG_LOG)
                {
                    AddLog(message, ex, LogLevels.DEBUG_LOG);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Write information
        /// </summary>
        /// <param name="message">Information message</param>
        public static void Info(string message)
        {
            try
            {
                LogLevels logLevel = GetLogLevelsEnum();
                if (logLevel <= LogLevels.INFO_LOG)
                {
                    AddLog(message, LogLevels.INFO_LOG);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Write information message and exception
        /// </summary>
        /// <param name="message">Information message</param>
        /// <param name="ex">Information exception</param>
        public static void Info(string message, Exception ex)
        {
            try
            {
                LogLevels logLevel = GetLogLevelsEnum();
                if (logLevel <= LogLevels.INFO_LOG)
                {
                    AddLog(message, ex, LogLevels.INFO_LOG);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Write warning message
        /// </summary>
        /// <param name="message">Warning message</param>
        public static void Warning(string message)
        {
            try
            {
                LogLevels logLevel = GetLogLevelsEnum();
                if (logLevel <= LogLevels.WARN_LOG)
                {
                    AddLog(message, LogLevels.WARN_LOG);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Write warning message and exception
        /// </summary>
        /// <param name="message">Warning message</param>
        /// <param name="ex">Warning Exception</param>
        public static void Warning(string message, Exception ex)
        {
            try
            {
                LogLevels logLevel = GetLogLevelsEnum();
                if (logLevel <= LogLevels.WARN_LOG)
                {
                    AddLog(message, ex, LogLevels.WARN_LOG);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Write error message
        /// </summary>
        /// <param name="message">Error message</param>
        public static void Error(string message)
        {
            try
            {
                LogLevels logLevel = GetLogLevelsEnum();
                if (logLevel <= LogLevels.ERROR_LOG)
                {
                    AddLog(message, LogLevels.ERROR_LOG);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Write error message and exception
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="ex">Error exception</param>
        public static void Error(string message, Exception ex)
        {
            try
            {
                LogLevels logLevel = GetLogLevelsEnum();
                if (logLevel <= LogLevels.ERROR_LOG)
                {
                    AddLog(message, ex, LogLevels.ERROR_LOG);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void AddLog(string message, LogLevels logLevel)
        {
            LogFactory logFac = LogFactory.GetFactory();
            ILog newLog = logFac.GetLogInstance(GetLogType());
            newLog.WriteEntry("[" + logLevel + "] " + message, logLevel);
        }

        private static void AddLog(string message, Exception ex, LogLevels logLevel)
        {
            LogFactory logFac = LogFactory.GetFactory();
            ILog newLog = logFac.GetLogInstance(GetLogType());
            newLog.WriteEntry("[" + logLevel + "] " + message, ex, logLevel);
        }

        private static LogLevels GetLogLevelsEnum()
        {
            LogLevels logLevel = LogLevels.DEBUG_LOG;
            try
            {
                logLevel = (LogLevels)(Enum.Parse(typeof(LogLevels), GetLogLevel(), true));
            }
            catch
            {
                //configuration error,default Log levels is "Debug".
            }
            return logLevel;
        }

    }
}
