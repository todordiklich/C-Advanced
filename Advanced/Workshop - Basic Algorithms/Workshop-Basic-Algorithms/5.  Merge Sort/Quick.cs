using System;

namespace _5.__Merge_Sort
{
    public class Quick<T> where T: IComparable
    {
        public static void Sort(T[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            int p = Partition(arr, lo, hi);
            Sort(arr, lo, p - 1);
            Sort(arr, p + 1, hi);
        }

        private static int Partition(T[] arr, int lo, int hi)
        {
            if (lo >= hi)
            {
                return lo;
            }

            int i = lo;
            int j = hi + 1;

            while (true)
            {
                while (Less(arr[++i], arr[lo]))
                {
                    if (i == hi) break;
                }
                while (Less(arr[lo], arr[--j]))
                {
                    if (j == lo) break;
                }

                if (i >= j) break;
                Swap(arr, i, j);
            }

            Swap(arr, lo, j);

            return j;
        }

        private static void Swap(T[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }

        private static bool Less(T first, T second)
        {
            return first.CompareTo(second) <= 0;
        }
    }
}
