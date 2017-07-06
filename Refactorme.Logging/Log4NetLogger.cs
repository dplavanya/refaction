using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;

namespace Refactorme.Logging
{
    public class Log4NetLogger : ILogger
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static Log4NetLogger()
        {
            // Auto Configure log4net
            //XmlConfigurator.Configure(); //Now done in AssemblyInfo.cs.
        }

        /// <summary>
        /// Log the specified message with a debug level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Debug(string message)
        {
            Logger.Logger.Log(typeof(Log4NetLogger), Level.Debug, message, null);
        }

        /// <summary>
        /// Log the specified message with an info level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Info(string message)
        {
            Logger.Logger.Log(typeof(Log4NetLogger), Level.Info, message, null);
        }

        /// <summary>
        /// Log the specified message with a warn level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="eventId">The associated eventId.</param>
        /// <param name="exceptionDetails">The exception to log, including its stack trace.</param>
        public void Warn(string message, int eventId, Exception exceptionDetails = null)
        {
            log4net.ThreadContext.Properties["EventID"] = eventId;
            Logger.Logger.Log(typeof(Log4NetLogger), Level.Warn, message, exceptionDetails);
        }

        /// <summary>
        /// Log the specified message with an error level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="eventId">The associated eventId.</param>
        /// <param name="exceptionDetails">The exception to log, including its stack trace.</param>
        public void Error(string message, int eventId, Exception exceptionDetails = null)
        {
            log4net.ThreadContext.Properties["EventID"] = eventId;
            Logger.Logger.Log(typeof(Log4NetLogger), Level.Error, message, exceptionDetails);
        }
    }
}
