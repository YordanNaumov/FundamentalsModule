using System;
using System.Collections.Generic;
using System.Linq;


namespace _2.Message_Decrypter
{
    class Program
    {
        static void Main()
        {
            int linesOfInput = int.Parse(Console.ReadLine());

            for (int p = 0; p < linesOfInput; p++)
            {
                bool allAreValid = true;
                string[] inputText = Console.ReadLine().
                    Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                if (inputText.Length != 2)
                {
                    Console.WriteLine("Valid message not found!");
                    continue;
                }

                //message
                string message = inputText[0];
                char firstSymbol = message[0];

                if (firstSymbol != '$' && firstSymbol != '%' || firstSymbol != message[message.Length - 1])
                {
                    allAreValid = false;
                }

                //tag
                string tag = string.Empty;
                for (int i = 1; i < message.Length - 1; i++)
                {
                    tag += message[i];
                }

                if (tag.Length < 3 || tag[0] < 65 || tag[0] > 90)
                {
                    allAreValid = false;
                }

                for (int i = 1; i < tag.Length; i++)
                {
                    if (tag[i] < 97 || tag[i] > 122)
                    {
                        allAreValid = false;
                    }
                }

                //numbers
                string[] numbers = inputText[1].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (numbers.Length != 3)
                {
                    Console.WriteLine("Valid message not found!");
                    continue;
                }
                bool firstNumberValid = NumbersAreValid(numbers[0]);
                bool secondNumberValid = NumbersAreValid(numbers[1]);
                bool thirdNumberValid = NumbersAreValid(numbers[2]);

                if (firstNumberValid == false || secondNumberValid == false || thirdNumberValid == false)
                {
                    allAreValid = false;
                }

                if (allAreValid)
                {
                    int firstNumber = GetsNumber(numbers[0]);
                    int secondNumber = GetsNumber(numbers[1]);
                    int thirdNumber = GetsNumber(numbers[2]);

                    string decryptedMessage = string.Empty;

                    decryptedMessage += Convert.ToChar(firstNumber);
                    decryptedMessage += Convert.ToChar(secondNumber);
                    decryptedMessage += Convert.ToChar(thirdNumber);

                    Console.WriteLine($"{tag}: {decryptedMessage}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }

        static bool NumbersAreValid(string number)
        {
            bool numberIsValid = true;

            if (number[0] != '[' || number[number.Length - 1] != ']')
            {
                numberIsValid = false;
            }
            for (int i = 1; i < number.Length-1; i++)
            {
                if (number[i] < 48 || number[i] > 57)
                {
                    numberIsValid = false;
                }
            }

            return numberIsValid;
        }

        static int GetsNumber(string input)
        {
            string numberAsString = string.Empty;

            for (int i = 1; i < input.Length - 1; i++)
            {
                numberAsString += input[i];
            }
            int number = int.Parse(numberAsString);

            return number;
        }
    }
}
