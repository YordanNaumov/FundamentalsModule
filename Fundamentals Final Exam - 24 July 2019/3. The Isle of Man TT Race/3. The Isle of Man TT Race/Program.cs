using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                bool allValid = true;
                string[] encryptedMessage = Console.ReadLine()
                    .Split('=')
                    .ToArray();

                if (encryptedMessage.Length < 2)
                {
                    allValid = false;
                    Console.WriteLine("Nothing found!");
                    continue;
                }
                string[] lengthAndCode = encryptedMessage[1]
                    .Split(new[] { "!!" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (lengthAndCode.Length < 2)
                {
                    allValid = false;
                    Console.WriteLine("Nothing found!");
                    continue;
                }
                //racer
                string racer = encryptedMessage[0];
                string racerName = string.Empty;
                char lastSymbol = racer[0];
                if (lastSymbol != '#' && lastSymbol != '$' && lastSymbol != '%' && lastSymbol != '*' && lastSymbol != '&')
                {
                    allValid = false;
                }
                for (int i = 1; i < racer.Length - 1; i++)
                {
                    if ((racer[i] < 65 || racer[i] > 90) && (racer[i] < 97 || racer[i] > 122))
                    {
                        allValid = false;
                    }
                    racerName += racer[i];
                }
                if (lastSymbol != racer[racer.Length - 1])
                {
                    allValid = false;
                }

                //length
                string length = lengthAndCode[0];

                for (int i = 0; i < length.Length; i++)
                {
                    if (length[i] < 48 || length[i] > 57)
                    {
                        allValid = false;
                    }
                }
                int lengthInNumber = int.Parse(length);

                //code
                string code = lengthAndCode[1];

                if (lengthAndCode.Length > 2)
                {
                    for (int i = 2; i < lengthAndCode.Length; i++)
                    {
                        code += "!!";
                        code += lengthAndCode[i];
                    }
                }

                if (code.Length != lengthInNumber)
                {
                    allValid = false;
                }

                if (allValid)
                {
                    string geohashCode = string.Empty;
                    for (int i = 0; i < code.Length; i++)
                    {
                        geohashCode += Convert.ToChar(code[i] + lengthInNumber);
                    }

                    Console.WriteLine($"Coordinates found! {racerName} -> {geohashCode}");
                    break;
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
