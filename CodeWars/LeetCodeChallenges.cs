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

        // There are n kids with candies. You are given an integer array candies, where each candies[i] represents the number of candies the ith kid has,
        // and an integer extraCandies, denoting the number of extra candies that you have.
        // Return a boolean array result of length n, where result[i] is true if, after giving the ith kid all the extraCandies,
        // they will have the greatest number of candies among all the kids, or false otherwise.
        // Note that multiple kids can have the greatest number of candies.
        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            ValidateCandiesInput(candies, extraCandies);

            var maxNumber = candies.Max();
            var result = new List<bool>();

            foreach (var candy in candies)
            {
                var currentAmount = candy + extraCandies;
                var hasGreatestNumber = (currentAmount >= maxNumber) ? true : false;
                result.Add(hasGreatestNumber);
            }

            ValidateCandiesResult(candies, result.ToArray());

            return result;
        }

        // You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.
        // Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n,
        // return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.
        public static bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            ValidateFlowerbedInput(flowerbed, n);

            if (n == 0 || n == 1 && flowerbed.All(x => x == 0))
            {
                return true;
            }

            var emptyPlotAtStart = new int[] { 0, 0, 1 };
            var emptyPlot = new int[] { 0, 0, 0 };
            var emptyPlotAtEnd = new int[] { 1, 0, 0 };
            var sequencesFound = new List<bool>();

            if (flowerbed.SequenceEqual(emptyPlot) && n <= 2)
            {
                return true;
            }

            for (int i = 0; i <= flowerbed.Length - emptyPlot.Length; i++)
            {
                var test = flowerbed.Skip(i).Take(emptyPlot.Length).ToList();

                if (i == 0 && (flowerbed.Skip(i).Take(emptyPlotAtStart.Length).SequenceEqual(emptyPlotAtStart)
                    || flowerbed.Skip(i).Take(emptyPlot.Length).SequenceEqual(emptyPlot)))
                {
                    sequencesFound.Add(true);
                    flowerbed.SetValue(1, i);
                }

                else if (flowerbed.Skip(i).Take(emptyPlot.Length).SequenceEqual(emptyPlot))
                {
                    sequencesFound.Add(true);
                    flowerbed.SetValue(1, i + 1);
                }

                else if (i == flowerbed.Length - 3 && flowerbed.Skip(i).Take(emptyPlotAtEnd.Length).SequenceEqual(emptyPlotAtEnd))
                {
                    sequencesFound.Add(true);
                    flowerbed.SetValue(1, flowerbed.Length - 1);
                }
            }

            if (HasAdjacentFlowers(flowerbed) ||
                sequencesFound.Any() && sequencesFound.Count(x => x) < n)
            {
                return false;
            }

            return sequencesFound.Any();
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

        private static void ValidateCandiesInput(int[] candies, int extraCandies)
        {
            if (!candies.Any())
            {
                throw new Exception("Empty candies list.");
            }

            foreach (var candy in candies)
            {
                if (candy < 1 || candy > 100)
                {
                    throw new Exception("The max number of candies per child should be between 1 and 100.");
                }
            }

            if (extraCandies < 1 || extraCandies > 50)
            {
                throw new Exception($"Invalid number of extra candies: {extraCandies}.");
            }
        }

        private static void ValidateCandiesResult(int[] candies, bool[] result)
        {
            if (candies.Length != result.Length || (result.Length < 2 || result.Length > 100))
            {
                throw new Exception("The length of the result list is invalid.");
            }
        }

        private static void ValidateFlowerbedInput(int[] flowerbed, int n)
        {
            if (flowerbed.Length == 0 || flowerbed is { Length: < 1 or > 20000 })
            {
                throw new Exception("The length of the flowerbed is invalid.");
            }

            if (!flowerbed.Any(x => x == 0 || x == 1))
            {
                throw new Exception("The collection should contain only 0 or 1.");
            }

            if (n < 0 || n > flowerbed.Length)
            {
                throw new Exception($"Invalid value of n: {n}.");
            }
        }

        private static bool HasAdjacentFlowers(int[] flowerbed)
        {
            var adjacentFlowers = new int[] { 1, 1 };

            for (int i = 0; i <= flowerbed.Length - adjacentFlowers.Length; i++)
            {
                if (flowerbed.Skip(i).Take(adjacentFlowers.Length).SequenceEqual(adjacentFlowers))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
