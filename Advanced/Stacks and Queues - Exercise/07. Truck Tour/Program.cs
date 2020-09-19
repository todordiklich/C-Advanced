using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<PetrolStation> pumps = new Queue<PetrolStation>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] num = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int liters = num[0];
                int distance = num[1];

                PetrolStation ps = new PetrolStation(liters, distance);

                pumps.Enqueue(ps);
            }

            int index = 0;

            while (true)
            {
                var totalFuel = 0;

                foreach (var pump in pumps)
                {
                    totalFuel += pump.Liters - pump.Distance;

                    if (totalFuel < 0)
                    {
                        var currentPumps = pumps.Dequeue();
                        pumps.Enqueue(currentPumps);
                        index++;
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }

    public class PetrolStation
    {
        public int Liters { get; set; }

        public int Distance { get; set; }

        public PetrolStation(int liters, int distance)
        {
            this.Liters = liters;
            this.Distance = distance;
        }
    }
}
