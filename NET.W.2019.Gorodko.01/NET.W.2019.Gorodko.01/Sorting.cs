using System;
using System.Collections.Generic;

/// <summary>
/// Contains sorting methods 
/// </summary>
public static class Sorting
{
    ///<summary>
    ///Orders the array
    /// </summary>
    /// <param name="array">Array which has to be ordered</param>
    public static void QuickSort(int[] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        if (array.Length <= 1)
            return;

        //contains boards of disordered parts of array
        var stack = new Stack<(int, int)>();
        stack.Push((0, array.Length - 1));

        while (stack.Count != 0)
        {
            (int left, int right) = stack.Pop();
            Console.WriteLine(left + " " + right);
            int cross = HoarePartition(array, left, right);

            if (cross > left)
                stack.Push((left, cross));
            if (cross + 1 < right)
                stack.Push((cross + 1, right));
        }
    }

    ///<summary>
    ///Returns the ordered array
    /// </summary>
    /// <param name="array">Array which has to be ordered</param>
    /// <returns>Ordered array</returns>
    public static int[] MergeSort(int[] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        if (array.Length <= 1)
            return array;

        //contains sorted arrays
        var queue = new Queue<int[]>();
        //devide source array 
        foreach (var item in array)
        {
            queue.Enqueue(new int[1] { item });
        }

        while(queue.Count != 1)
        {
            queue.Enqueue(Merge(queue.Dequeue(), queue.Dequeue()));
        }

        return queue.Dequeue();
    }

    private static int HoarePartition(int[] array, int low, int high)
    {
        int pivot = array[(low + high) / 2];

        int i = low - 1;
        int j = high + 1;

        while (true)
        {
            do { } while (array[++i] < pivot && i < high);
            do { } while (array[--j] > pivot && j > low);

            //if indexes are crossed
            if (i >= j)
                return j;

            //else change elements
            (array[i], array[j]) = (array[j], array[i]);
        }
    }

    private static int[] Merge(int[] array1, int[] array2)
    {
        var resultArray = new int[array1.Length + array2.Length];

        int array1Index = 0, array2Index = 0;
        for (int resIndex = 0; resIndex < resultArray.Length; resIndex++)
        {
            //if the first array is fully in the result array
            if (array1Index >= array1.Length)
            {
                resultArray[resIndex] = array2[array2Index++];
            }
            //if the second array is fully in the result array
            else if (array2Index >= array2.Length)
            {
                resultArray[resIndex] = array1[array1Index++];
            }
            else if (array1[array1Index] < array2[array2Index])
            {
                resultArray[resIndex] = array1[array1Index++];
            }
            else
            {
                resultArray[resIndex] = array2[array2Index++];
            }
        }

        return resultArray;
    }
}