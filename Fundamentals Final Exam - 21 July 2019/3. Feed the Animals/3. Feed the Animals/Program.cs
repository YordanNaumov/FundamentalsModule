using System;
using System.Collections.Generic;
using System.Linq;


namespace _3.Feed_the_Animals
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> animalAndFood = new Dictionary<string, int>();
            Dictionary<string, int> locationAndAnimals = new Dictionary<string, int>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(':').ToArray();

                if (command[0] == "Last Info")
                {
                    break;
                }
                else if (command[0] == "Add")
                {
                    string name = command[1];
                    int foodLimit = int.Parse(command[2]);
                    string area = command[3];

                    if (animalAndFood.ContainsKey(name))
                    {
                        animalAndFood[name] += foodLimit;
                    }
                    else
                    {
                        animalAndFood[name] = foodLimit;
                    }
                }
                else //Feed
                {
                    
                }
            }
            
        }
    }
}
