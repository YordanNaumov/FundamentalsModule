using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Song_Encryption
{
    class Program
    {
        static void Main()
        {
            Regex validInformation = new Regex(@"(?<!\w )\b([A-Z][a-z ']+)\b:([A-Z ]+)");
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                else if (validInformation.IsMatch(command))
                {
                    string[] artistAndSong = command.Split(':').ToArray();
                    string artist = artistAndSong[0];
                    string song = artistAndSong[1];
                    int key = artist.Length;

                    string encryptedArtist = Encryption(artist, key);
                    string encryptedSong = Encryption(song, key);

                    Console.WriteLine($"Successful encryption: {encryptedArtist}@{encryptedSong}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static string Encryption(string word, int key)
        {
            string encryptedWord = string.Empty;

            for (int i = 0; i < word.Length; i++)
            {
                char newLetter = word[i];

                if (word[i] != ' ' && Convert.ToInt32(word[i]) != 39)
                {
                    int letterNumber = Convert.ToInt32(word[i]);
                    int encryptedNumber = letterNumber + key;

                    if (letterNumber >= 97 && letterNumber <= 122 && encryptedNumber > 122)
                    {
                        encryptedNumber -= 26;
                    }
                    else if (letterNumber <= 90 && letterNumber >= 65 && encryptedNumber > 90)
                    {
                        encryptedNumber -= 26;
                    }

                    newLetter = Convert.ToChar(encryptedNumber);
                }
                encryptedWord += newLetter;
            }
            return encryptedWord;
        }
    }
}
