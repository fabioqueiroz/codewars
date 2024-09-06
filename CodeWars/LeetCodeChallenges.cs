using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeWars
{
    public class LeetCodeChallenges
    {
        // You are given two strings word1 and word2. Merge the strings by adding letters in alternating order, starting with word1.
        // If a string is longer than the other, append the additional letters onto the end of the merged string.
        public static string MergeAlternately(string word1, string word2)
        {
            ValidateStringInput(word1, word2);

            var words = new List<string> { word1.ToLower(), word2.ToLower() };

            var output = string.Empty;
            
            if (word1.Length == word2.Length)
            {
                for (int i = 0; i < word1.Length; i++)
                {
                    output += $"{word1[i]}{word2[i]}";
                }
            }

            if (word1.Length > word2.Length)
            {
                for (int i = 0; i < word2.Length; i++)
                {
                    output += $"{word1[i]}{word2[i]}";
                }

                output += word1.Substring(word2.Length);
            }

            if (word1.Length < word2.Length)
            {
                for (int i = 0; i < word1.Length; i++)
                {
                    output += $"{word1[i]}{word2[i]}";
                }

                output += word2.Substring(word1.Length);
            }

            return output;
        }

        // For two strings s and t, we say "t divides s" if and only if s = t + t + t + ... + t + t (i.e., t is concatenated with itself one or more time
        // Given two strings str1 and str2, return the largest string x such that x divides both str1 and str2.
        public static string GcdOfStrings(string str1, string str2)
        {
            if (str1.Length < 1 || str1.Length > 1000 ||
                str2.Length < 1 || str2.Length > 1000)
            {
                throw new Exception("Invalid length.");
            }

            if (!str1.Contains(str2) && !str2.Contains(str1) || 
                (str1.Any(letter => !str2.Contains(letter)) || 
                str2.Any(letter => !str1.Contains(letter))))
            {
                return string.Empty;
            }

            return GetOutput(str1, str2);
        }


        private static int CalculateGCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }

        private static string GetOutput(string str1, string str2)
        {
            var letterRegex = "^(.+?)\\1+$";
            var repeatedPattern = Regex.Split(str1, letterRegex, RegexOptions.IgnoreCase).Single(pattern => !string.IsNullOrEmpty(pattern));
            var repeatedPattern2 = Regex.Split(str2, letterRegex, RegexOptions.IgnoreCase).Single(pattern => !string.IsNullOrEmpty(pattern));

            if (!repeatedPattern.Equals(repeatedPattern2))
            {
                return string.Empty;
            }

            var occurrences1 = Regex.Matches(str1, repeatedPattern).Count;
            var occurrences2 = Regex.Matches(str2, repeatedPattern).Count;

            var gcd = CalculateGCD(occurrences1, occurrences2);

            var results = Enumerable.Range(0, gcd).Select(_ => repeatedPattern);

            return string.Concat(results);
        }

        private static void ValidateStringInput(params string[] words)
        {
            if(!words.Any())
            {
                throw new Exception("No words have been provided.");
            }

            foreach (var word in words) 
            {
                if (string.IsNullOrEmpty(word))
                {
                    throw new ArgumentNullException("The input cannot be null.");
                }

                if (word.Length < 1 || word.Length > 100)
                {
                    throw new Exception($"Invalid length for {nameof(word)}.");
                }
            }
        }
    }
}
