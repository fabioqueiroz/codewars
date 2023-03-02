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

        #region Sum of odd numbers
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
            //return n*n*n;
            return (long)Math.Pow(n, 3);
        }

        //public static long RowSumOddNumbers(long n)
        //{
        //    var numbers = new List<int>();
        //    var firstNumber = (int)(n * (n - 1)) + 1;
        //    var nextNumber = firstNumber;

        //    for (int i = 0; i < n; i++)
        //    {
        //        if (nextNumber == firstNumber)
        //        {
        //            numbers.Add(firstNumber);
        //        }
        //        else
        //        {
        //            numbers.Add(nextNumber);
        //        }
        //        nextNumber += 2;
        //    }

        //    return numbers.Sum();
        //}
        #endregion

        #region Growth of the population
        // In a small town the population is p0 = 1000 at the beginning of a year. The population regularly increases by
        // 2 percent per year and moreover 50 new inhabitants per year come to live in the town. How many years does the town need
        // to see its population greater or equal to p = 1200 inhabitants?
        // ex:
        // At the end of the first year there will be: 
        // 1000 + 1000 * 0.02 + 50 => 1070 inhabitants
        // At the end of the 2nd year there will be: 
        // 1070 + 1070 * 0.02 + 50 => 1141 inhabitants(** number of inhabitants is an integer **)
        // At the end of the 3rd year there will be:
        // 1141 + 1141 * 0.02 + 50 => 1213

        // More generally given parameters:
        // p0, percent, aug(inhabitants coming or leaving each year), p(population to equal or surpass)
        // the function nb_year should return n number of entire years needed to get a population greater or equal to p.
        // aug is an integer, percent a positive or null floating number, p0 and p are positive integers(> 0)
        // ex:
        // Examples:
        // nb_year(1500, 5, 100, 5000) -> 15
        // nb_year(1500000, 2.5, 10000, 2000000) -> 10
        // Note:
        // Don't forget to convert the percent parameter as a percentage in the body of your function: if the parameter percent is 2 you have to convert it to 0.02.
        public static int NbYear(int p0, double percent, int aug, int p)
        {
            var years = 0;
            var inhabitants = p0;

            while (inhabitants < p) 
            {
                inhabitants = (int)(inhabitants * ((percent / 100) + 1)) + aug;
                years++;
            }

            return years;
            //return p0 >= p ? 0 : 1 + NbYear((int) (p0 + p0 * percent / 100 + aug), percent, aug, p);
        }
        #endregion

        // Write a function that accepts an array of 10 integers (between 0 and 9), that returns a string of those numbers in the form of a phone number.
        // ex: CreatePhoneNumber(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}) // => returns "(123) 456-7890"
        public static string CreatePhoneNumber(int[] numbers)
        {
            //return $"({numbers[0]}{numbers[1]}{numbers[2]})" + " " + $"{numbers[3]}{numbers[4]}{numbers[5]}-{numbers[6]}{numbers[7]}{numbers[8]}{numbers[9]}";
            return int.Parse(string.Concat(numbers)).ToString("(000) 000-0000");
        }
    }
}
