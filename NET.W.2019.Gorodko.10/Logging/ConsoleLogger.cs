using System;
using Logging.Abstract;

namespace Logging
{
    /// <inheritdoc/>
    public class ConsoleLogger : ILogger
    {
        private static volatile ConsoleLogger instance;
        private static readonly object sync = new object();

        private ConsoleLogger()
        { }

        /// <summary>
        /// Gets the instance of console logger.
        /// </summary>
        public static ConsoleLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new ConsoleLogger();
                        }
                    }
                }
                return instance;
            }
        }

        /// <inheritdoc/>
        public void Log(string message)
        {
            if (message == null)
            {
                Console.WriteLine("Something went wrong.");
            }

            Console.WriteLine(message);
        }
    }
}
