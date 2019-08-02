using System;
using System.Collections.Generic;
using System.Linq;


namespace _1.Concert
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> bandAndMemebrs = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandAndTime = new Dictionary<string, int>();
            int totalTime = 0;

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "start of concert")
                {
                    break;
                }
                else if (command[0] == "Add")
                {
                    string bandName = command[1];

                    if (bandAndMemebrs.ContainsKey(bandName) == false)
                    {
                        bandAndMemebrs[bandName] = new List<string>();
                    }
                    string[] members = command[2]
                        .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    for (int i = 0; i < members.Length; i++)
                    {
                        if (bandAndMemebrs[bandName].Contains(members[i]) == false)
                        {
                            bandAndMemebrs[bandName].Add(members[i]);
                        }
                    }
                }
                else if (command[0] == "Play")
                {
                    string bandName = command[1];
                    int time = int.Parse(command[2]);
                    totalTime += time;

                    if (bandAndTime.ContainsKey(bandName))
                    {
                        bandAndTime[bandName] += time;
                    }
                    else
                    {
                        bandAndTime[bandName] = time;
                    }
                }
            }

            bandAndTime = bandAndTime
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Total time: {totalTime}");

            foreach (var band in bandAndTime)
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            string finalBandName = Console.ReadLine();
            Console.WriteLine(finalBandName);

            foreach (var member in bandAndMemebrs[finalBandName])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
