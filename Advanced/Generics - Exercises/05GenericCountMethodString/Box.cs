using System;
using System.Collections.Generic;
using System.Text;

namespace _05GenericCountMethodString
{
    public class Box
    {
        public static int Comparison<T>(List<T> list, T element)
            where T: IComparable
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
