namespace Logging.Abstract
{
    /// <summary>
    /// Provides logging.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the message.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Log(string message);
    }
}
