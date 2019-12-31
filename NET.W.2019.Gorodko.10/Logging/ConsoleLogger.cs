using System;
using Logging.Abstract;

namespace Logging
{
    public class ConsoleLogger : ILogger
    {
        private static volatile ConsoleLogger instance;
        private static readonly object sync = new object();

        private ConsoleLogger()
        { }

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
