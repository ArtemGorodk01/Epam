using System;
using System.Collections;
using System.Collections.Generic;

namespace Task1
{
    /// <summary>
    /// My queue.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue</typeparam>
    public class Queue<T> : IEnumerable<T>, ICollection
    {
        #region Private fields

        /// <summary>
        /// The internal storage.
        /// </summary>
        private T[] array;

        /// <summary>
        /// The size of the internal array.
        /// </summary>
        private int capacity;

        #endregion

        #region Constructors

        /// <summary>
        /// Initials the new queue.
        /// </summary>
        /// <param name="count">Start count of elements.</param>
        public Queue(int capacity = 0)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Count must be larger than 0.");
            }

            this.array = new T[capacity];
        }

        /// <summary>
        /// Initials the new queue using the array.
        /// </summary>
        /// <param name="elements">The initials array.</param>
        public Queue(params T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            this.capacity = elements.Length;
            this.array = new T[capacity];
            Count = capacity;
            elements.CopyTo(this.array, 0);
        }

        #endregion

        #region Queue methods

        /// <summary>
        /// Adds new element to the end of the queue.
        /// </summary>
        /// <param name="element">New element.</param>
        public void Enqueue(T element)
        {
            if (this.Count == this.capacity)
            {
                if (this.capacity == 0)
                {
                    capacity = 1;
                }

                this.capacity *= 2;
                Array.Resize(ref this.array, this.capacity);
            }

            this.array[Count++] = element;
        }

        /// <summary>
        /// Removes and returns the first element from the queue.
        /// </summary>
        /// <returns>The first element from the queue.</returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Nothing to dequeue.");
            }

            var firstElement = this.array[0];
            Array.Copy(this.array, 1, this.array, 0, --this.Count);
            return firstElement;
        }

        /// <summary>
        /// Returns the first element from the queue.
        /// </summary>
        /// <returns>The first element from the queue.</returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Nothing to peek.");
            }

            return this.array[0];
        }

        /// <summary>
        /// Resizes the internal array.
        /// </summary>
        public void Defragment()
        {
            if (Count != 0)
            {
                Array.Resize(ref this.array, Count);
            }
            else
            {
                this.capacity = 1;
                this.array = new T[this.capacity];
            }
        }

        /// <summary>
        /// Returns is the element in the queue.
        /// </summary>
        /// <param name="element">The element to compare with.</param>
        /// <returns>Is the element in the queue.</returns>
        public bool Contains(T element)
        {
            foreach (var item in this.array)
            {
                if (object.Equals(item, element))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region ICollection

        /// <inheritdoc>
        public int Count { get; private set; }

        /// <inheritdoc/>
        public object SyncRoot { get; }

        /// <inheritdoc />
        public bool IsSynchronized => false;

        /// <inheritdoc/>
        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array is T[])
            {
                throw new ArrayTypeMismatchException("Wrong type of array");
            }

            if (array.Length < this.Count)
            {
                throw new ArgumentException("The length of array is less than length of collection.");
            }

            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            this.array.CopyTo(array, index);
        }

        #endregion

        #region IEnumerable<T> and IEnumerable

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => new QueueEnumerator<T>(this);

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        #endregion

        #region Enumerator

        public class QueueEnumerator<Q> : IEnumerator<Q>
        {
            /// <summary>
            /// The source queue.
            /// </summary>
            private readonly Queue<Q> queue;

            /// <summary>
            /// The current index in the collection.
            /// </summary>
            private int currentIndex;

            /// <summary>
            /// Initials new enumerator.
            /// </summary>
            /// <param name="queue">The source queue.</param>
            public QueueEnumerator(Queue<Q> queue)
            {
                this.currentIndex = -1;
                this.queue = queue ?? throw new ArgumentNullException(nameof(queue));
            }

            /// <inheritdoc/>
            public Q Current => this.queue.array[currentIndex];

            /// <inheritdoc/>
            object IEnumerator.Current => this.Current;

            /// <inheritdoc/>
            public bool MoveNext()
            {
                if (++currentIndex < this.queue.Count)
                {
                    return true;
                }

                this.Reset();
                return false;
            }

            /// <inheritdoc/>
            public void Reset()
            {
                currentIndex = -1;
            }

            /// <inheritdoc/>
            public void Dispose()
            {
            }
        }

        #endregion
    }
}
