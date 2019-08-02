using System;
using System.Linq;
using System.Collections.Generic;

namespace TEST
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                string[] command = Console.ReadLine().Split(':').ToArray();

                if (command[0] == "end")
                {
                    break;
                }
                string artist = command[0];
                string song = command[1];
                bool bothValid = true;

                if (artist[0] < 65 || artist[0] > 90)
                {
                    bothValid = false;
                }
                for (int i = 1; i < artist.Length; i++)
                {
                    if ((artist[i] < 97 || artist[i] > 122) && artist[i] != 32 && artist[i] != 39)
                    {
                        bothValid = false;
                    }
                }

                for (int i = 0; i < song.Length; i++)
                {
                    if ((song[i] < 65 || song[i] > 90) && song[i] != 32)
                    {
                        bothValid = false;
                    }
                }

                if (bothValid)
                {
                    string encryptedArtist = Encryption(artist, artist.Length);
                    string encryptedSong = Encryption(song, artist.Length);

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

