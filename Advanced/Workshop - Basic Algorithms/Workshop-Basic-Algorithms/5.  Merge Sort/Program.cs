using System;
using System.Diagnostics;

namespace _5.__Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int n = 10;
            int[] arr = new int[n];
            int[] arr1 = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = arr1[i] = rand.Next(0, n);
            }

            Stopwatch watch = new Stopwatch();
            watch.Start();
            Quick<int>.Sort(arr);
            watch.Stop();
            Console.WriteLine($"Quck sort took: {watch.ElapsedMilliseconds} ms");

            watch.Reset();
            watch.Start();
            Mergesort<int>.Sort(arr1);
            watch.Stop();
            Console.WriteLine($"Merge sort took: {watch.ElapsedMilliseconds} ms");

            //Console.WriteLine(string.Join(", ", arr));
            //Console.WriteLine(string.Join(", ", arr1));

            watch.Reset();
            watch.Start();
            
           
            int m = 1000000000;
            int[] arr2 = new int[m];
            for (int i = 0; i < m; i++)
            {
                arr2[i] = i;
            }
            Console.WriteLine($"Creating array with {m} elements took: {watch.ElapsedMilliseconds} ms");
            watch.Stop();

            watch.Reset();
            watch.Start();
            int index = BinarySearch.IndexOf(arr, m/3);
            Console.WriteLine($"Binary Search took {watch.ElapsedMilliseconds} ms");
            watch.Stop();
        }
    }
}
