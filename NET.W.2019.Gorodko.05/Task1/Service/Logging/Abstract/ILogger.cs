namespace Task1.Service.Logging.Abstract
{
    /// <summary>
    /// Logger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Information messages
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);

        /// <summary>
        /// Trace messages
        /// </summary>
        /// <param name="message"></param>
        void Trace(string message);

        /// <summary>
        /// Messages for debugging
        /// </summary>
        /// <param name="message"></param>
        void Debug(string message);

        /// <summary>
        /// Warning
        /// </summary>
        /// <param name="message"></param>
        void Warn(string message);

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);

        /// <summary>
        /// Fatal error
        /// </summary>
        /// <param name="message"></param>
        void Fatal(string message);
    }
}
