using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _2.Race
{
    class Program
    {
        static void Main()
        {
            string[] participants = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Regex regexName = new Regex(@"[A-Za-z]+");
            Regex regexDistance = new Regex(@"\d");
            Dictionary<string, int> participantsAndDistance = new Dictionary<string, int>();
            string command = Console.ReadLine();

            while (command != "end of race")
            {
                var matchedParticipants = regexName.Matches(command);
                string name = string.Empty;

                foreach (Match match in matchedParticipants)
                {
                    name += match.Value.ToString();
                }

                var matchedDistance = regexDistance.Matches(command);
                int distance = 0;

                foreach (Match number in matchedDistance)
                {
                    distance += int.Parse(number.Value.ToString());
                }

                if (participantsAndDistance.ContainsKey(name))
                {
                    participantsAndDistance[name] += distance;
                }
                else if (participants.Contains(name))
                {
                    participantsAndDistance[name] = distance;
                }

                command = Console.ReadLine();
            }
            participantsAndDistance = participantsAndDistance.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            List<string> Names = new List<string>();
            
            foreach (var member in participantsAndDistance)
            {
                Names.Add(member.Key);
            }

            Console.WriteLine($"1st place: {Names[0]}");
            Console.WriteLine($"2nd place: {Names[1]}");
            Console.WriteLine($"3rd place: {Names[2]}");
        }
    }
}