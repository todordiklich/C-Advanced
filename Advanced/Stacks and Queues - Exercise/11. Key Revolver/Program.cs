using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int value = int.Parse(Console.ReadLine());

            Queue<int> lockQueue = new Queue<int>(locks);
            Stack<int> bulletsStack = new Stack<int>(bullets);
            Queue<int> barrel = new Queue<int>();

            Reload(gunBarrelSize, bulletsStack, barrel);

            int bulletsShoot = 0;

            while (lockQueue.Count > 0)
            {
                if (barrel.Count > 0 || bulletsStack.Count > 0)
                {
                    if (barrel.Count > 0)
                    {
                        int currLock = lockQueue.Peek();
                        int currBullet = barrel.Dequeue();
                        bulletsShoot++;

                        if (currBullet <= currLock)
                        {
                            Console.WriteLine("Bang!");
                            lockQueue.Dequeue();
                        }
                        else
                        {
                            Console.WriteLine("Ping!");
                        }
                    }
                    if (barrel.Count == 0 && bulletsStack.Count > 0)
                    {
                        Reload(gunBarrelSize, bulletsStack, barrel);
                        Console.WriteLine("Reloading!");
                    }
                }
                else
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {lockQueue.Count}");
                    return;
                }
            }

            Console.WriteLine($"{bulletsStack.Count + barrel.Count} bullets left. Earned ${value - (bulletsShoot * bulletPrice)}");
        }

        private static void Reload(int gunBarrelSize, Stack<int> bulletsStack, Queue<int> barrel)
        {
            if (bulletsStack.Count > 0 && bulletsStack.Count < gunBarrelSize)
            {
                while (bulletsStack.Count > 0)
                {
                    barrel.Enqueue(bulletsStack.Pop());
                }
            }
            else
            {
                for (int i = 0; i < gunBarrelSize; i++)
                {
                    barrel.Enqueue(bulletsStack.Pop());
                }
            }
        }
    }
}
