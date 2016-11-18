using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public enum MyArraySortDirection { LowToHight, HightToLow };
    public enum ArraySortMethod
    {
        SortSelection, SortInsertion, SortBuble,
        SortShells, QuickSort
    };



    public class MyArray<T> where T : IComparable
    { 

        public static bool ArrayCompareInt(T[] strArray1, T[] strArray2)
        {
            if (strArray1.Length != strArray2.Length)
                return false;
            for (int i = 0; i < strArray1.Length; i++)
                if (!(strArray1[i].Equals(strArray2[i])))
                {
                    return false;
                }
            return true;
        }

        public static T[] ToArrayInt(params T[] list)
        {
            int i;
            T[] arrResult = new T[list.Length];
            for (i = 0; i < list.Length; i++)
            {
                arrResult[i] = list[i];
            }
            return arrResult;
        }


        public static T[] AddArrayInt(T[] arr, T volume, int vol)
        {
            T[] arrResult = new T[arr.Length + 1];

            if (vol != 0)
            {
                arrResult[0] = volume;
                for (int i = 0; i < arr.Length; i++)
                    arrResult[i + 1] = arr[i];
                return arrResult;
            }

            if (vol == arr.Length - 1)
            {
                for (int i = 0; i < arr.Length; i++)
                    arrResult[i] = arr[i];
                arrResult[arrResult.Length - 1] = volume;
                return arrResult;
            }
            for (int i = 0; i < vol; i++)
                arrResult[i] = arr[i];
            arrResult[vol] = volume;
            for (var i = vol + 1; vol < arr.Length; i++)
                arrResult[i] = arr[i - 1];
            return arrResult;
        }

        public static T[] DelFromArrayInt(T[] strArray, int index)
        {
            T[] arrResult = new T[strArray.Length - 1];
            int resultCount = 0;
            int i = 0;

            while (resultCount != arrResult.Length)
            {
                if (i != index)
                {
                    arrResult[resultCount] = strArray[i];
                    resultCount++;
                }
                i++;
            }
            return arrResult;
        }

        public static void ArraySortSelection(T[] arrayIn, MyArraySortDirection direction)
        {
            int i = 0;
            int j = 0;
            T temp;
            for (i = 0; i < arrayIn.Length; i++)
            {
                for (j = i + 1; j < arrayIn.Length; j++)
                {
                    if (
                        (direction == MyArraySortDirection.LowToHight) && (arrayIn[i].CompareTo(arrayIn[j]) > 0)
                        ||
                        (direction == MyArraySortDirection.HightToLow) && (arrayIn[i].CompareTo(arrayIn[j]) < 0)
                        )
                    {
                        temp = arrayIn[i];
                        arrayIn[i] = arrayIn[j];
                        arrayIn[j] = temp;
                    }
                }
            }
            return;
        }

        public static void ArraySortInsertion(T[] arrayIn, MyArraySortDirection direction)
        {
            int i = 0;
            int j = 0;
            T temp;

            for (i = 1; i < arrayIn.Length; i++)
            {
                temp = arrayIn[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (((temp.CompareTo(arrayIn[j]) > 0) && (direction == MyArraySortDirection.LowToHight))
                        ||
                        ((temp.CompareTo(arrayIn[j]) < 0) && (direction == MyArraySortDirection.HightToLow)))

                    {
                        arrayIn[j + 1] = temp;
                        break;
                    }
                    else
                    {
                        arrayIn[j + 1] = arrayIn[j];
                        if (j == 0)
                        {
                            arrayIn[j] = temp;
                        }
                    }
                }
            }
            return;
        }

        public static void ArraySortBuble(T[] arrayIn, MyArraySortDirection direction)
        {
            bool sorted = true;
            T temp;
            int leng = 0;
            while (sorted)
            {
                sorted = false;
                for (int i = 0; i < arrayIn.Length - 1 - leng; i++)
                {
                    temp = arrayIn[i];
                    if (((temp.CompareTo(arrayIn[i + 1]) > 0) && (direction == MyArraySortDirection.LowToHight))
                        ||
                        ((temp.CompareTo(arrayIn[i + 1]) < 0) && (direction == MyArraySortDirection.HightToLow)))
                    {
                        arrayIn[i] = arrayIn[i + 1];
                        arrayIn[i + 1] = temp;
                        sorted = true;
                    }
                }
                leng++;
            }
            return;
        }

        public static void ArraySortShells(T[] arrayIn, MyArraySortDirection direction)
        {
            int i = 0;
            int j = 0;
            T temp;
            int step = 0;
            for (step = arrayIn.Length - 1; step > 0; step--)
            {
                i = 0;
                for (i = 0; i < arrayIn.Length - 1; i++)
                {
                    j = i + step;
                    if (j > arrayIn.Length - 1)
                        j = arrayIn.Length - 1;
                    if (((arrayIn[i].CompareTo(arrayIn[j]) > 0) && (direction == MyArraySortDirection.LowToHight))
                        ||
                        ((arrayIn[i].CompareTo(arrayIn[j]) < 0) && (direction == MyArraySortDirection.HightToLow)))
                    {
                        temp = arrayIn[i];
                        arrayIn[i] = arrayIn[j];
                        arrayIn[j] = temp;
                    }
                }
            }
            return;
        }

        public static void ArrayQuickSort(T[] arrayIn, MyArraySortDirection direction)
        {
            Quicksort(arrayIn, 0, arrayIn.Length - 1, direction);
        }
        private static void Quicksort(T[] elements, int left, int right, MyArraySortDirection direction)
        {
            if (elements.Length == 0)
                return;

            int i = left, j = right;
            T pivot = elements[(left + right) / 2];

            switch (direction)
            {
                case MyArraySortDirection.HightToLow:

                    while (i <= j)
                    {
                        while (elements[i].CompareTo(pivot) > 0)

                        {
                            i++;
                        }
                        while (elements[j].CompareTo(pivot) < 0)
                        {
                            j--;
                        }
                        if (i <= j)
                        {
                            // Swap
                            T tmp = elements[i];
                            elements[i] = elements[j];
                            elements[j] = tmp;
                            i++;
                            j--;
                        }
                    }
                    break;
                default:

                    while (i <= j)
                    {
                        while (elements[i].CompareTo(pivot) < 0)
                        {
                            i++;
                        }
                        while (elements[j].CompareTo(pivot) > 0)
                        {
                            j--;
                        }
                        if (i <= j)
                        {
                            // Swap
                            T tmp = elements[i];
                            elements[i] = elements[j];
                            elements[j] = tmp;
                            i++;
                            j--;
                        }
                    }
                    break;
            }
            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j, direction);
            }
            if (i < right)
            {
                Quicksort(elements, i, right, direction);
            }
        }
        public static void ArraySort(T[] arrayIn, MyArraySortDirection direction,
            ArraySortMethod sort = ArraySortMethod.QuickSort)
        {
            //SortSelection, SortInsertion, SortBuble,SortShells, QuickSort
            switch (sort)
            {
                case ArraySortMethod.QuickSort:
                    ArrayQuickSort(arrayIn, direction);
                    break;
                case ArraySortMethod.SortSelection:
                    ArraySortSelection(arrayIn, direction);
                    break;
                case ArraySortMethod.SortInsertion:
                    ArraySortInsertion(arrayIn, direction);
                    break;
                case ArraySortMethod.SortBuble:
                    ArraySortBuble(arrayIn, direction);
                    break;
                case ArraySortMethod.SortShells:
                    ArraySortShells(arrayIn, direction);
                    break;
                default:
                    throw new NotSupportedException();
                    //break;

            }
        }

      
    
   

       
    }

}
