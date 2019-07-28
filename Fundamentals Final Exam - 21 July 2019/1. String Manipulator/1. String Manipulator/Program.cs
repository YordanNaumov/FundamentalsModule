using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.String_Manipulator
{
    class Program
    {
        static void Main()
        {
            string information = string.Empty;
            string[] command = Console.ReadLine().Split().ToArray();

            while (command[0] != "End")
            {
                if (command[0] == "Add")
                {
                    information += command[1];
                }
                else if (command[0] == "Upgrade")
                {
                    char oldChar = Convert.ToChar(command[1]);
                    char newChar = Convert.ToChar(Convert.ToInt32(oldChar) + 1);
                    information = information.Replace(oldChar, newChar);
                }
                else if (command[0] == "Print")
                {
                    Console.WriteLine(information);
                }
                else if (command[0] == "Index")
                {
                    List<int> indexes = new List<int>();
                    int containsIndex = information.IndexOf(Convert.ToChar(command[1]));
                    if (containsIndex == -1)
                    {
                        Console.WriteLine("None");
                    }
                    else
                    {
                        while (containsIndex != -1)
                        {
                            indexes.Add(containsIndex);
                            containsIndex = information.IndexOf(Convert.ToChar(command[1]), containsIndex + 1);
                        }
                        Console.WriteLine(string.Join(" ", indexes));
                    }
                }
                else if (command[0] == "Remove")
                {
                    while (information.Contains(command[1]))
                    {
                        int containsIndex = information.IndexOf(command[1]);
                        information = information.Remove(containsIndex, command[1].Length);
                    }
                }
                
                command = Console.ReadLine().Split().ToArray();
            }
        }
    }
}
