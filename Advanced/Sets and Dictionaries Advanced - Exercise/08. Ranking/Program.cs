using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsData = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> studentsData
                = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "end of contests")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(new char[] { ':', '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string contestName = cmdArgs[0];
                string contestPass = cmdArgs[1];

                if (!contestsData.ContainsKey(contestName))
                {
                    contestsData.Add(contestName, contestPass);
                }
            }

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "end of submissions")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split(new char[] { ':', '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string contestName = cmdArgs[0];
                string contestPass = cmdArgs[1];
                string studentName = cmdArgs[2];
                int points = int.Parse(cmdArgs[3]);

                

                if (contestsData.ContainsKey(contestName)) // check if contest exist
                {
                    if (contestsData[contestName] == contestPass) // check if password is correct
                    {
                        if (!studentsData.ContainsKey(studentName)) // check if user exist
                        {
                            studentsData.Add(studentName, new Dictionary<string, int>()); // create student
                        }

                        if (!studentsData[studentName].ContainsKey(contestName)) // check if student has contest
                        {
                            studentsData[studentName].Add(contestName, points); // add contest and points to student
                        }
                        else // student has repeated contest
                        {
                            if (studentsData[studentName][contestName] < points) // check if has more points
                            {
                                studentsData[studentName][contestName] = points;
                            }
                        }
                    }
                }
            }
            var bestStudent = studentsData.OrderByDescending(v => v.Value.Values.Sum()).ToDictionary(k => k.Key, v=> v.Value);

            Console.WriteLine($"Best candidate is {bestStudent.First().Key} with total {bestStudent.First().Value.Values.Sum()} points.");

            Console.WriteLine("Ranking:");
            foreach (var student in studentsData.OrderBy( s => s.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var contest in student.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
