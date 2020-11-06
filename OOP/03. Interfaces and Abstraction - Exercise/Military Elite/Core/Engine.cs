using System;
using System.Linq;
using System.Collections.Generic;

using MilitaryElite.Models;
using MilitaryElite.Contracts;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private ICollection<ISoldier> soldiers;
        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string soldierType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    soldier = AddPrivate(cmdArgs, id, firstName, lastName);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    soldier = AddGeneral(cmdArgs, id, firstName, lastName);

                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    try
                    {
                        soldier = CreateEngineer(cmdArgs, id, firstName, lastName, salary, corps);
                    }

                    catch (InvalidCorpsException ice)
                    {
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    try
                    {
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                        string[] missionArgs = cmdArgs.Skip(6).ToArray();

                        for (int i = 0; i < missionArgs.Length; i += 2)
                        {
                            try
                            {
                                string missionCodeName = missionArgs[i];
                                string missionState = missionArgs[i + 1];

                                IMission mission = new Mission(missionCodeName, missionState);

                                commando.AddMission(mission);
                            }
                            catch (InvalidMissionStateException ime)
                            {
                            }
                        }
                        soldier = (ISoldier)commando;
                    }
                    catch (InvalidCorpsException ice)
                    {
                        Console.WriteLine(ice.Message);
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                if (soldier != null)
                {
                    soldiers.Add(soldier);
                }
            }

            foreach (var soldier in this.soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }

        private static ISoldier CreateEngineer(string[] cmdArgs, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ISoldier soldier;
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            string[] repairArgs = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                string partName = repairArgs[i];
                int hoursWorked = int.Parse(repairArgs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);

                engineer.AddRepair(repair);
            }

            soldier = (ISoldier)engineer;
            return soldier;
        }

        private ISoldier AddGeneral(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var pid in cmdArgs.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers
                    .First(s => s.Id == int.Parse(pid));

                general.AddPrivate(privateToAdd);
            }

            soldier = (ISoldier)general;
            return soldier;
        }

        private static ISoldier AddPrivate(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            soldier = new Private(id, firstName, lastName, salary);

            return soldier;
        }
    }
}
