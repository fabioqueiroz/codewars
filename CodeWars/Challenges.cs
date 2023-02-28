using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeWars
{
    public class Challenges
    {
        public static string FindWhoLikesThePost(string[] names)
        {
            return names.Length switch
            {
                0 => "no one likes this",
                1 => $"{names[0]} likes this",
                2 => $"{names[0]} and {names[1]} like this",
                3 => $"{names[0]}, {names[1]} and {names[2]} like this",
                _ => $"{names[0]}, {names[1]} and {names.Length - 2} others like this",
            };
        }

        //A pangram is a sentence that contains every single letter of the alphabet at least once. For example,
        //the sentence "The quick brown fox jumps over the lazy dog" is a pangram, because it uses the letters A-Z at least once (case is irrelevant).
        //Given a string, detect whether or not it is a pangram.Return True if it is, False if not. Ignore numbers and punctuation.
        public static bool IsPangram(string str)
        {
            var isPangram = false;
            var alphabet = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            var lettersRegex = new Regex("[^a-zA-Z -]");
            str = lettersRegex.Replace(str, string.Empty).ToLower().Replace(" ", string.Empty);

            foreach (var letter in alphabet)
            {
                foreach (var character in str.ToCharArray())
                {
                    isPangram = str.ToCharArray().ToList().Contains(char.Parse(letter));
                }
            }
            return isPangram;
        }
    }
}
