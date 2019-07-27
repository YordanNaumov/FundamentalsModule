using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1.Furniture
{
    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            List<string> boughtItems = new List<string>();
            double sumTotal = 0;
            
            while (command != "Purchase")
            {
                Regex regex = new Regex(@">>(.*)<<([\d]+\.[\d]*|[\d]+)!([\d]+)");//>>([\w\s]+)<<([\d]+\.[\d]*|[\d]+)!([\d]+)
                var matches = regex.Matches(command);

                foreach (Match match in matches)
                {
                    boughtItems.Add(match.Groups[1].ToString());
                    double sum = Convert.ToDouble(match.Groups[2].ToString());
                    int quantity = int.Parse(match.Groups[3].ToString());
                    sumTotal += sum * Convert.ToDouble(quantity);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (var item in boughtItems)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {sumTotal:f2}");
        }
    }
}
