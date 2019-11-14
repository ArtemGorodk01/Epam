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

    [TestMethod]
    public void QuickSort_TransformsSourceArraysCorrectly()
    {
        var arr1 = new int[] { 1 };
        var arr2 = new int[] { 1, 2 };
        var arr3 = new int[] { 2, 3, 1, 5, 4 };
        var arr4 = new int[] { 4, 2, 1, 5, 8, 3, 9, 7, 0, 6 };
        var arr5 = new int[] { };
        var arr6 = new int[] { -3, 1, 8, 9, 0, 2, 3, 1 };

        Sorting.QuickSort(arr1);
        Sorting.QuickSort(arr2);
        Sorting.QuickSort(arr3);
        Sorting.QuickSort(arr4);
        Sorting.QuickSort(arr5);
        Sorting.QuickSort(arr6);

        Assert.IsTrue(AreSame(arr1, new int[] { 1 }));
        Assert.IsTrue(AreSame(arr2, new int[] { 1, 2 }));
        Assert.IsTrue(AreSame(arr3, new int[] { 1, 2, 3, 4, 5 }));
        Assert.IsTrue(AreSame(arr4, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        Assert.IsTrue(AreSame(arr5, new int[] { }));
        Assert.IsTrue(AreSame(arr6, new int[] { -3, 0, 1, 1, 2, 3, 8, 9 }));
    }

    [TestMethod]
    public void MergeSort_ArrayIsNull_TrowsArgumentNullException()
    {
        Assert.ThrowsException<ArgumentNullException>(() => Sorting.MergeSort(null));
    }

    [TestMethod]
    public void MergeSort_ReturnsRightArray()
    {
        var arr1 = new int[] { 1 };
        var arr2 = new int[] { 1, 2 };
        var arr3 = new int[] { 2, 3, 1, 5, 4 };
        var arr4 = new int[] { 4, 2, 1, 5, 8, 3, 9, 7, 0, 6 };
        var arr5 = new int[] { };
        var arr6 = new int[] { -3, 1, 8, 9, 0, 2, 3, 1 };

        Assert.IsTrue(AreSame(Sorting.MergeSort(arr1), new int[] { 1 }));
        Assert.IsTrue(AreSame(Sorting.MergeSort(arr2), new int[] { 1, 2 }));
        Assert.IsTrue(AreSame(Sorting.MergeSort(arr3), new int[] { 1, 2, 3, 4, 5 }));
        Assert.IsTrue(AreSame(Sorting.MergeSort(arr4), new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        Assert.IsTrue(AreSame(Sorting.MergeSort(arr5), new int[] { }));
        Assert.IsTrue(AreSame(Sorting.MergeSort(arr6), new int[] { -3, 0, 1, 1, 2, 3, 8, 9 }));
    }

    private bool AreSame(int[] array1, int[] array2)
    {
        if (array1.Length != array2.Length)
            return false;

        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
                return false;
        }

        return true;
    }
}
