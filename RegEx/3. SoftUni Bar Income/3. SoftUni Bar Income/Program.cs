using System;
using System.Text.RegularExpressions;

namespace _3.SoftUni_Bar_Income
{
    class Program
    {
        static void Main()
        {
            string command = Console.ReadLine();
            Regex regex = new Regex(@"%([A-Z][a-z]+)%\w*<\b([\w]+)\b>\w*\|(\d+)\|[^\|\$\%\.0-9]*(\d+\.*\d*)\$\w*");//input 1a10,3
            //%([A-Z][a-z]+)%\w*<\b([\w]+)\b>\w*\|(\d+)\|\w*(\d+\.*\d*)\$\w*
            double totalIncome = 0;
            while (command != "end of shift")
            {
                bool orderIsValid = regex.IsMatch(command);
                
                if (orderIsValid == true)
                {
                    var validOrder = regex.Match(command);
                    double price = double.Parse(validOrder.Groups[4].Value.ToString()) * double.Parse(validOrder.Groups[3].Value.ToString());
                    totalIncome += price;
                    Console.WriteLine($"{validOrder.Groups[1].Value}: {validOrder.Groups[2].Value} - {price:f2}");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
