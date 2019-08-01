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

                        if (locationAndAnimals.ContainsKey(area))
                        {
                            locationAndAnimals[area] += 1;
                        }
                        else
                        {
                            locationAndAnimals[area] = 1;
                        }
                    }
                }
                else //Feed
                {
                    string name = command[1];
                    int food = int.Parse(command[2]);
                    string area = command[3];

                    if (animalAndFood.ContainsKey(name))
                    {
                        animalAndFood[name] -= food;

                        if (animalAndFood[name] <= 0)
                        {
                            Console.WriteLine($"{name} was successfully fed");
                            animalAndFood.Remove(name);
                            locationAndAnimals[area] -= 1;
                        }
                    }
                }
            }

            animalAndFood = animalAndFood
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Animals:");

            foreach (var animal in animalAndFood)
            {
                Console.WriteLine($"{animal.Key} -> {animal.Value}g");
            }

            locationAndAnimals = locationAndAnimals
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Areas with hungry animals:");

            foreach (var animal in locationAndAnimals)
            {
                if (animal.Value >= 1)
                {
                    Console.WriteLine($"{animal.Key} : {animal.Value}");
                }
            }
        }
    }
}
