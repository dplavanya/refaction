using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorme.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// Log the specified message with a debug level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Debug(string message);

        /// <summary>
        /// Log the specified message with an info level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void Info(string message);

        /// <summary>
        /// Log the specified message with a warn level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="eventId">The associated eventId.</param>
        /// <param name="exceptionDetails">The exception to log, including its stack trace.</param>
        void Warn(string message, int eventId, Exception exceptionDetails = null);

        /// <summary>
        /// Log the specified message with an error level.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="eventId">The associated eventId.</param>
        /// <param name="exceptionDetails">The exception to log, including its stack trace.</param>
        void Error(string message, int eventId, Exception exceptionDetails = null);
    }
}
