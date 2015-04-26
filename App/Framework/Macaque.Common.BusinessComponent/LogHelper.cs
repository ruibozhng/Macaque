using Macaque.Common.BusinessEntity;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macaque.Common.BusinessComponent
{
    public class LogHelper
    {
        /// <summary>
        /// Write to log
        /// </summary>
        /// <param name="logEntity"></param>
        public static void Write(LogEntity logEntity)
        {
            LogEntry logEntry = new LogEntry(
                logEntity.Content,
                logEntity.Category != null ? logEntity.Category : "Default",
                -1, System.Threading.Thread.CurrentThread.ManagedThreadId,
                System.Diagnostics.TraceEventType.Information,
                logEntity.Title != null ? logEntity.Title : AppDomain.CurrentDomain.FriendlyName,
                new Dictionary<string, object>());

            logEntry.TimeStamp = DateTime.Now;

            SetDefaultEnvironmentVariables();

            if (logEntity.EnvironmentVariable != null)
                foreach (string key in logEntity.EnvironmentVariable.Keys)
                    SetEnvironmentVariable(key, logEntity.EnvironmentVariable[key]);

            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Writer.Write(logEntry);
        }

        /// <summary>
        /// Write to log
        /// </summary>
        /// <param name="message"></param>
        public static void Write(string message)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.Content = message;
            Write(logEntity);
        }

        /// <summary>
        /// Set default environment variables to current process
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetDefaultEnvironmentVariables()
        {
        }

        /// <summary>
        /// Set environment variables to current process
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetEnvironmentVariable(string key, string value)
        {
            Environment.SetEnvironmentVariable(key, value, EnvironmentVariableTarget.Process);
        }
    }
}
