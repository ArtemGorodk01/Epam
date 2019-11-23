using System;
using NET.W._2019.Gorodko._02.Task4;
using NUnit.Framework;

namespace NET.W._2019.Gorodko._02.NUnitTests
{
    [TestFixture]
    public class FilterTests
    {
        [Test]
        public void FilterDigits_ArrayIsNull_ThrowsArgumentNUllException()
        {
            Assert.Throws<ArgumentNullException>(() => Filter.FilterDigit(1, null));
        }

        [Test]
        public void FilterDigits_DigitIsNotDigit_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Filter.FilterDigit(12, 1));
        }

        [TestCase(7, new int[] { 12, 17, 12, 14, 7, }, new int[] { 17, 7 })]
        [TestCase(5, new int[] { 13, 5, 12, 555, 185 }, new int[] { 5, 555, 185 })]
        public void FilterDigits_ReturnsRightSequence(int digit, int[] source, int[] expected)
        {
            Assert.AreEqual(expected, Filter.FilterDigit(digit, source));
        }
    }
}
