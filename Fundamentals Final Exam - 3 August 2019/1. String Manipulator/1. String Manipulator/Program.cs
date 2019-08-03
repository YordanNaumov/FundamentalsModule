using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.String_Manipulator
{
    class Program
    {
        static void Main()
        {
            string inputText = Console.ReadLine();

            while (true)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                if (command[0] == "End")
                {
                    break;
                }
                else if (command[0] == "Translate")
                {
                    char charToReplace = Convert.ToChar(command[1]);
                    char replacement = Convert.ToChar(command[2]);

                    //while (inputText.Contains(charToReplace))
                    //{
                        inputText = inputText.Replace(charToReplace, replacement);
                    //}
                    Console.WriteLine(inputText);
                }
                else if (command[0] == "Includes")
                {
                    bool contains = inputText.Contains(command[1]);
                    Console.WriteLine(contains);
                }
                else if (command[0] == "Start")
                {
                    int starts = inputText.IndexOf(command[1]);
                    if (starts == 0)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command[0] == "Lowercase")
                {
                    inputText = inputText.ToLower();
                    Console.WriteLine(inputText);
                }
                else if (command[0] == "FindIndex")
                {
                    char letter = Convert.ToChar(command[1]);
                    int lastIndex = inputText.LastIndexOf(letter);
                    Console.WriteLine(lastIndex);
                }
                else if (command[0] == "Remove")
                {
                    int startIndex = int.Parse(command[1]);
                    int count = int.Parse(command[2]);
                    string newText = string.Empty;
                    for (int i = 0; i < inputText.Length; i++)
                    {
                        if (i < startIndex || i > startIndex + count - 1)
                        {
                            newText += inputText[i];
                        }
                    }
                    inputText = newText;
                    Console.WriteLine(inputText);
                }
            }
        }
    }
}
