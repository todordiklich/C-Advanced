using System;
using System.Linq;
using System.Collections.Generic;

namespace _4._Set_Cover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> universeSet = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int n = int.Parse(Console.ReadLine());
            Dictionary<int, List<int>> sets = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> usedSets = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                List<int> set = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                sets[i] = set;
            }

            List<int> keysToRemove = new List<int>();

            foreach (var set in sets.OrderByDescending(s => s.Value.Count))
            {
                keysToRemove.Add(set.Key);
                break;
            }
            foreach (var set in sets)
            {
                if (!keysToRemove.Contains(set.Key))
                {
                    keysToRemove.Add(set.Key);
                }
            }

            foreach (var key in keysToRemove)
            {
                bool hasWon = false;

                for (int i = 0; i < sets[key].Count; i++)
                {
                    if (universeSet.Contains(sets[key][i]))
                    {
                        universeSet.Remove(sets[key][i]);
                        usedSets[key] = sets[key];
                    }
                    if (universeSet.Count == 0)
                    {
                        hasWon = true;
                        break;
                    }
                }
                if (hasWon)
                {
                    break;
                }
            }

            Console.WriteLine($"Sets to take ({usedSets.Count}):");
            foreach (var set in usedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set.Value)} }}");
            }
        }
    }
}
