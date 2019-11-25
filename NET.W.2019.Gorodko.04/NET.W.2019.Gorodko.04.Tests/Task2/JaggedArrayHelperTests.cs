using System;
using NET.W._2019.Gorodko._04.Task2;
using NUnit.Framework;

namespace NET.W._2019.Gorodko._04.Tests.Task2
{
    [TestFixture]
    public class JaggedArrayHelperTests
    {
        [Test]
        public void Sort_ArrayIsNull_ThrowsArgumentNullExcption()
        {
            int[][] array = null;

            Assert.Throws<ArgumentNullException>(() => array.Sort((a, b) => a == b, true));
        }

        [Test]
        public void Sort_CompareIsNull_ThrowsArgumentNullException()
        {
            var array = new int[1][];
            array[0] = new int[] { 1 };

            Assert.Throws<ArgumentNullException>(() => array.Sort(null, true));
        }

        [Test]
        public void Sort_CompareArraySum_ReturnsRightResult()
        {
            var array = new int[5][];
            array[0] = new int[] { 1, 2, 3 };
            array[1] = new int[] { 1, 2, 3, 4 };
            array[2] = new int[] { 1, 2 };
            array[3] = new int[] { 1, 2, 3, 4, 5 };
            array[4] = new int[] { 1 };

            var expected = new int[5][];
            expected[0] = new int[] { 1 };
            expected[1] = new int[] { 1, 2 };
            expected[2] = new int[] { 1, 2, 3 };
            expected[3] = new int[] { 1, 2, 3, 4 };
            expected[4] = new int[] { 1, 2, 3, 4, 5 };

            array.Sort(JaggedArrayHelper.CompareArraySum, true);

            Assert.IsTrue(AreJaggedArraysSame(expected, array));
        }

        [Test]
        public void Sort_CompareArrayMax_ReturnsRightResult()
        {
            var array = new int[5][];
            array[0] = new int[] { 1, 2, 3 };
            array[1] = new int[] { 1, 2, 3, 4 };
            array[2] = new int[] { 1, 2 };
            array[3] = new int[] { 1, 2, 3, 4, 5 };
            array[4] = new int[] { 1 };

            var expected = new int[5][];
            expected[0] = new int[] { 1 };
            expected[1] = new int[] { 1, 2 };
            expected[2] = new int[] { 1, 2, 3 };
            expected[3] = new int[] { 1, 2, 3, 4 };
            expected[4] = new int[] { 1, 2, 3, 4, 5 };

            array.Sort(JaggedArrayHelper.CompareArrayMax, true);

            Assert.IsTrue(AreJaggedArraysSame(expected, array));
        }

        [Test]
        public void Sort_CompareArrayMin_ReturnsRightResult()
        {
            var array = new int[5][];
            array[0] = new int[] { 1, 2, 3 };
            array[1] = new int[] { -1, 2, 3, 4 };
            array[2] = new int[] { -11, 2 };
            array[3] = new int[] { -111, 2, 3, 4, 5 };
            array[4] = new int[] { 3 };

            var expected = new int[5][];
            expected[0] = new int[] { -111, 2, 3, 4, 5 };
            expected[1] = new int[] { -11, 2 };
            expected[2] = new int[] { -1, 2, 3, 4 };
            expected[3] = new int[] { 1, 2, 3 };
            expected[4] = new int[] { 3 };

            array.Sort(JaggedArrayHelper.CompareArrayMin, true);

            Assert.IsTrue(AreJaggedArraysSame(expected, array));
        }

        private bool AreJaggedArraysSame(int[][] array1, int[][] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (!AreArraysSame(array1[i], array2[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool AreArraysSame(int[] array1, int[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
