using NLog;

namespace Task1.Service.Logging
{
    /// <summary>
    /// NLog logger
    /// </summary>
    public class NLogger : Abstract.ILogger
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Information messages
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            if (message == null)
            {
                return;
            }

            logger.Info(message);
        }

        /// <summary>
        /// Trace messages
        /// </summary>
        /// <param name="message"></param>
        public void Trace(string message)
        {
            if (message == null)
            {
                return;
            }

            logger.Trace(message);
        }

        /// <summary>
        /// Messages for debugging
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message)
        {
            if (message == null)
            {
                return;
            }

            logger.Debug(message);
        }

        /// <summary>
        /// Warning
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message)
        {
            if (message == null)
            {
                return;
            }

            logger.Warn(message);
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            if (message == null)
            {
                return;
            }

            logger.Error(message);
        }

        /// <summary>
        /// Fatal error
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(string message)
        {
            if (message == null)
            {
                return;
            }

            logger.Fatal(message);
        }
    }
}
