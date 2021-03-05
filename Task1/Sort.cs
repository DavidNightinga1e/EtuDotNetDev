using System;
using System.Collections.Generic;

namespace Task1
{
    public static class Sort
    {
        public static void InsertionSort<T>(this List<T> list) where T : IComparable<T>
        {
            for (int i = 1; i < list.Count; i++)
            {
                var cur = list[i];
                var j = i;
                while (j > 0 && cur.CompareTo(list[j - 1]) < 0)
                {
                    list[j] = list[j - 1];
                    j--;
                }

                list[j] = cur;
            }
        }
    }
}