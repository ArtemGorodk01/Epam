using System;
using NUnit.Framework;

namespace Task1.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Constructor_ParameterIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Queue<ValueType>(null));
            Assert.Throws<ArgumentNullException>(() => new Queue<object>(null));
        }

        [Test]
        public void Constructor_CapacityIsLess0_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Queue<ValueType>(-1));
            Assert.Throws<ArgumentException>(() => new Queue<object>(-1));
        }

        [TestCase(new int[] { 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 2, 3, 4 }, ExpectedResult = 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = 6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, ExpectedResult = 7)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, ExpectedResult = 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, ExpectedResult = 9)]
        public int Count_ReturnsRightValue(int[] parameters)
        {
            var queue = new Queue<int>(parameters);
            return queue.Count;
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void Foreach_ReturnsRightValues(int[] parameters)
        {
            var queue = new Queue<int>(parameters);
            int arrayIndex = 0;
            bool isRight = true;

            foreach (var item in queue)
            {
                if (!item.Equals(parameters[arrayIndex++]))
                {
                    isRight = false;
                    break;
                }
            }

            Assert.IsTrue(isRight);
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void Enqueue_AddsElements(int[] parameters)
        {
            var queue = new Queue<int>();
            int arrayIndex = 0;
            bool isRight = true;

            foreach (var item in parameters)
            {
                queue.Enqueue(item);
            }

            foreach (var item in queue)
            {
                if (!item.Equals(parameters[arrayIndex++]))
                {
                    isRight = false;
                    break;
                }
            }

            Assert.IsTrue(isRight);
        }

        [Test]
        public void Dequeue_EmptyQueue_ThrowsInvalidOperationException()
        {
            var queue = new Queue<int>();

            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = 1)]
        [TestCase(new int[] { 2, 3, 4, 5, 6, 7 }, ExpectedResult = 2)]
        [TestCase(new int[] { 3, 4, 5, 6, 7, 8 }, ExpectedResult = 3)]
        [TestCase(new int[] { 4, 5, 6, 7, 8, 9 }, ExpectedResult = 4)]
        public int Dequeue_ReturnsRightElement(int[] parameters)
        {
            var queue = new Queue<int>(parameters);

            return queue.Dequeue();
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, ExpectedResult = 1)]
        [TestCase(new int[] { 2, 3, 4, 5, 6, 7 }, ExpectedResult = 2)]
        [TestCase(new int[] { 3, 4, 5, 6, 7, 8 }, ExpectedResult = 3)]
        [TestCase(new int[] { 4, 5, 6, 7, 8, 9 }, ExpectedResult = 4)]
        public int Peek_ReturnsRightElement(int[] parameters)
        {
            var queue = new Queue<int>(parameters);

            return queue.Peek();
        }
    }
}
