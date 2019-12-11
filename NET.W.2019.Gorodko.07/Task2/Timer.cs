using System;
using System.Threading;

namespace Task2
{
    /// <summary>
    /// Timer
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Event handler
        /// </summary>
        private event EventHandler Handler;

        /// <summary>
        /// Instance
        /// </summary>
        private static Timer instance;

        /// <summary>
        /// Object for synchronization
        /// </summary>
        private static readonly object sync = new object();

        /// <summary>
        /// Double check singlton
        /// </summary>
        public static Timer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new Timer();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Private constructor
        /// </summary>
        private Timer()
        { }

        /// <summary>
        /// Starts timer. Invokes handler when time is out
        /// </summary>
        /// <param name="milliseconds">Time in milliseconds</param>
        public void Start(int milliseconds)
        {
            if (milliseconds < 0)
            {
                throw new ArgumentException($"parameter {nameof(milliseconds)} must be larger than 0");
            }

            Thread.Sleep(milliseconds);
            OnTimeOut(this, new EventArgs());
        }

        /// <summary>
        /// Adds method(handler) to internal event
        /// </summary>
        /// <param name="handler">Handler</param>
        public void Subscribe(EventHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            this.Handler += handler;
        }

        /// <summary>
        /// Removes method(handler) from internal event
        /// </summary>
        /// <param name="handler">Handler</param>
        public void Unsubscribe(EventHandler handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            this.Handler -= handler;
        }

        /// <summary>
        /// Invokes when time in timer is out
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="arg">Additional arguments</param>
        protected virtual void OnTimeOut(object sender, EventArgs arg)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (arg == null)
            {
                throw new ArgumentNullException(nameof(arg));
            }

            this.Handler?.Invoke(sender, arg);
        }
    }
}
