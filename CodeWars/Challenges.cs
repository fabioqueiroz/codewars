using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // A pangram is a sentence that contains every single letter of the alphabet at least once. For example,
        // the sentence "The quick brown fox jumps over the lazy dog" is a pangram, because it uses the letters A-Z at least once (case is irrelevant).
        // Given a string, detect whether or not it is a pangram.Return True if it is, False if not. Ignore numbers and punctuation.
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

        #region Divisors
        // Create a function named divisors/Divisors that takes an integer n > 1 and returns an array with all of the integer's divisors(except for 1 and the number itself),
        // from smallest to largest. If the number is prime return the string '(integer) is prime' (null in C#)
        // ex: Kata.Divisors(12) => new int[] {2, 3, 4, 6};
        //     Kata.Divisors(25) => new int[] {5};
        //     Kata.Divisors(13) => null;
        public static int[] Divisors(int n)
        {
            var numbers = Enumerable.Range(1, n).Where(i => n % i == 0 && (i > 1 && i < n)).ToArray();
            return numbers.Any() ? numbers : null!;
        }

        //public static int[] Divisors(int n)
        //{
        //    var numbers = new List<int>();

        //    if (n > 1)
        //    {
        //        for (int i = 1; i <= n; i++)
        //        {
        //            if (n % i == 0 && (i > 1 && i < n))
        //            {
        //                numbers.Add(i);
        //            }
        //        }
        //    }

        //    return numbers.Any() ? numbers.ToArray() : null!;
        //}
        #endregion

        #region Isogram
        // An isogram is a word that has no repeating letters, consecutive or non-consecutive. Implement a function that determines whether
        // a string that contains only letters is an isogram. Assume the empty string is an isogram. Ignore letter case.
        // Example: (Input --> Output)
        // "Dermatoglyphics" --> true "aba" --> false "moOse" --> false (ignore letter case)
        public static bool IsIsogram(string str)
        {
            var lettersArray = str.ToLower().ToCharArray();
            return lettersArray.Length == lettersArray.Distinct().Count();
        }

        //public static bool IsIsogram(string str)
        //{
        //    var lettersArray = str.ToLower().ToCharArray();
        //    Array.Sort(lettersArray);

        //    for (int i = 0; i < str.Length - 1; i++)
        //    {
        //        if (lettersArray[i] == lettersArray[i + 1])
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        #endregion

        // ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot contain anything but exactly 4 digits or exactly 6 digits.
        public static bool ValidatePin(string pin)
        {
            //return Regex.IsMatch(pin, @"^(\d{4}|\d{6})\z");
            return pin.All(n => char.IsDigit(n)) && (pin.Length == 4 || pin.Length == 6);
        }

        // Given the triangle of consecutive odd numbers:
        //              1
        //           3     5
        //        7     9    11
        //    13    15    17    19
        // 21    23    25    27    29
        // ...
        // Calculate the sum of the numbers in the nth row of this triangle (starting at index 1) e.g.:
        // 1 -->  1
        // 2 --> 3 + 5 = 8
        public static long RowSumOddNumbers(long n)
        {
            //var numbers = new List<int>();
            //var firstNumber = (int)(n * (n - 1)) + 1;
            //var nextNumber = firstNumber;

            //for (int i = 0; i < n; i++)
            //{
            //    if (nextNumber == firstNumber)
            //    {
            //        numbers.Add(firstNumber);
            //    }
            //    else
            //    {
            //        numbers.Add(nextNumber);
            //    }
            //    nextNumber += 2;
            //}

            //return numbers.Sum();

            //return n*n*n;
            return (long)Math.Pow(n, 3);
        }
    }
}
