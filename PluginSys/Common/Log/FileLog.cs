using System;
using System.Collections.Generic;
using System.Web;
using log4net;

namespace Maticsoft.Common
{
    /// <summary>
    /// Provides logging management service
    /// </summary>
    internal class FileLog : AbstractLog
    {
        //Pre-defined logger name in web.config or app.config
        public const string LOGGER_NAME = "MainLog";
        public static log4net.ILog Logger = log4net.LogManager.GetLogger(LOGGER_NAME);

        /// <summary>
        /// Add a debug log
        /// </summary>
        /// <param name="debugMessage"></param>
        public void Debug(string debugMessage)
        {
            Logger.Debug(debugMessage);
        }

        /// <summary>
        /// Add a debug log with an exception
        /// </summary>
        /// <param name="debugMessage"></param>
        /// <param name="ex"></param>
        public void Debug(string debugMessage, Exception ex)
        {
            Logger.Debug(GenerateMessage(debugMessage, ex));
        }

        /// <summary>
        /// Add a info log
        /// </summary>
        /// <param name="infoMessage"></param>
        public void Info(string infoMessage)
        {
            Logger.Info(infoMessage);
        }

        /// <summary>
        /// Add a info log with an exception
        /// </summary>
        /// <param name="infoMessage"></param>
        /// <param name="ex"></param>
        public void Info(string infoMessage, Exception ex)
        {
            Logger.Info(GenerateMessage(infoMessage, ex));
        }

        /// <summary>
        /// Add a warning log
        /// </summary>
        /// <param name="warnMessage"></param>
        public void Warning(string warnMessage)
        {
            Logger.Warn(warnMessage);
        }

        /// <summary>
        /// Add a warning log with an exception
        /// </summary>
        /// <param name="warnMessage"></param>
        /// <param name="ex"></param>
        public void Warning(string warnMessage, Exception ex)
        {
            Logger.Warn(GenerateMessage(warnMessage, ex));

        }

        /// <summary>
        /// Add a error log
        /// </summary>
        /// <param name="errorMessage"></param>
        public void Error(string errorMessage)
        {
            Logger.Error(errorMessage);
        }

        /// <summary>
        /// Add a error log with an exception
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="ex"></param>
        public void Error(string errorMessage, Exception ex)
        {
            Logger.Error(GenerateMessage(errorMessage, ex));
        }

        public override void WriteEntry(string message, LogLevels logLevel)
        {
            switch (logLevel)
            {
                case LogLevels.DEBUG_LOG:
                    this.Debug(message);
                    break;
                case LogLevels.ERROR_LOG:
                    this.Error(message);
                    break;
                case LogLevels.INFO_LOG:
                    this.Info(message);
                    break;
                case LogLevels.WARN_LOG:
                    this.Warning(message);
                    break;
            }
        }

        public override void WriteEntry(string message, Exception ex, LogLevels logLevel)
        {
            switch (logLevel)
            {
                case LogLevels.DEBUG_LOG:
                    this.Debug(message, ex);
                    break;
                case LogLevels.ERROR_LOG:
                    this.Error(message, ex);
                    break;
                case LogLevels.INFO_LOG:
                    this.Info(message, ex);
                    break;
                case LogLevels.WARN_LOG:
                    this.Warning(message, ex);
                    break;
            }
        }

        /// <summary>
        /// Add a acitivity log, default is succeeded.
        /// </summary>
        /// <param name="activityDesc"></param>
        public void AddActivity(string activityDesc)
        {
            Logger.Info(activityDesc);
        }

        public void AddActivity(string activityDesc, bool isSucceed)
        {
            Logger.Info(activityDesc + ". " + (isSucceed ? "Succeeded." : "Failed."));
        }

        private string GenerateMessage(string message, Exception ex)
        {
            return message + Environment.NewLine + GetCustomErrStr(ex);
        }
    }
}
