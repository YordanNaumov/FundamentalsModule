using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _2.Emoji_Sumator
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Regex validEmoji = new Regex(@" +(:([a-z]{4,50}):)[ |!*|\?|,*|\.*]");

            var matchedEmoji = validEmoji.Matches(input);
            int totalPower = 0;
            List<string> allEmoji = new List<string>();
            List<string> finalEmoji = new List<string>();

            foreach (Match matched in matchedEmoji)
            {
                string emoji = matched.Groups[2].Value;
                string emojiFinal = matched.Groups[1].Value;
                allEmoji.Add(emoji);
                finalEmoji.Add(emojiFinal);
                for (int i = 0; i < emoji.Length; i++)
                {
                    totalPower += Convert.ToInt32(emoji[i]);
                }
            }

            int[] numbers = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
            string wordInNumbers = string.Empty;

            for (int i = 0; i < numbers.Length; i++)
            {
                char letter = Convert.ToChar(numbers[i]);
                wordInNumbers += letter;
            }

            if (allEmoji.Contains(wordInNumbers))
            {
                totalPower *= 2;
            }

            if (allEmoji.Count >= 1)
            {
                Console.Write("Emojis found: ");
                Console.WriteLine(string.Join(", ", finalEmoji));
            }
            Console.WriteLine($"Total Emoji Power: {totalPower}");
        }
    }
}
