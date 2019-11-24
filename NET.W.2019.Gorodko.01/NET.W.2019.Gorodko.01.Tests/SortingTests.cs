using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SortingTests
{
    [TestMethod]
    public void QuickSort_ArrayIsNull_TrowsArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(() => Sorting.QuickSort(null));
    }

    [DataTestMethod]
    [DataRow(new int[] { 1 }, new int[] { 1 })]
    [DataRow(new int[] { 1, 2 }, new int[] { 1, 2 })]
    [DataRow(new int[] { 2, 3, 1, 5, 4 }, new int[] { 1, 2, 3, 4, 5 })]
    [DataRow(new int[] { 4, 2, 1, 5, 8, 3, 9, 7, 0, 6 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
    [DataRow(new int[] { }, new int[] { })]
    [DataRow(new int[] { -3, 1, 8, 9, 0, 2, 3, 1 }, new int[] { -3, 0, 1, 1, 2, 3, 8, 9 })]
    public void QuickSort_TransformsSourceArraysCorrectly(int[] source, int[] expected)
    {
        Sorting.QuickSort(source);

        Assert.IsTrue(AreSame(source, expected));
    }

    [TestMethod]
    public void MergeSort_ArrayIsNull_TrowsArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(() => Sorting.MergeSort(null));
    }

    [TestMethod]
    [DataTestMethod]
    [DataRow(new int[] { 1 }, new int[] { 1 })]
    [DataRow(new int[] { 1, 2 }, new int[] { 1, 2 })]
    [DataRow(new int[] { 2, 3, 1, 5, 4 }, new int[] { 1, 2, 3, 4, 5 })]
    [DataRow(new int[] { 4, 2, 1, 5, 8, 3, 9, 7, 0, 6 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
    [DataRow(new int[] { }, new int[] { })]
    [DataRow(new int[] { -3, 1, 8, 9, 0, 2, 3, 1 }, new int[] { -3, 0, 1, 1, 2, 3, 8, 9 })]
    public void MergeSort_TransformsSourceArraysCorrectly(int[] source, int[] expected)
    {
        Assert.IsTrue(AreSame(Sorting.MergeSort(source), expected));
    }

    private bool AreSame(int[] array1, int[] array2)
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
