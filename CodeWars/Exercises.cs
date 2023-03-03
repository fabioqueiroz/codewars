using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeWars
{
    public class Exercises
    {
        // Given a string and a separator, write a method that adds separator between each adjacent characters in a string.
        // ex: AddSeparator("ABCD", "^") → "A^B^C^D"
        public static string AddSeparator(string input, string separator)
        {
            return string.Join(separator, input.ToCharArray());
        }

        // Given a string, write a method that returns that string in reverse order.
        public static string ReverseOrder(string input)
        {
            //var result = new StringBuilder();
            //for (int i = input.Length - 1; i >= 0; i--)
            //{
            //    result.Append(input[i]);
            //}
            //return result.ToString();

            return string.Concat(input.Reverse());
        }

        // Given a string, write a method which returns sum of all digits in that string. Assume that string contains only single digits.
        public static int FindSumOfDigits(string input)
        {
            return input.Where(c => char.IsDigit(c)).Select(c => (int)char.GetNumericValue(c)).Sum();
        }

        // Given a string, write a method that returns new string in which every odd letter of the word is uppercase.
        // String may consist of one or more words.
        public static string MakeUppercase(string input) 
        {
            //var result = new StringBuilder();
            //for (int i = 0; i < input.Length; i++)
            //{
            //    _ = (i % 2 == 0) ? result.Append(char.ToUpper(input[i])) : result.Append(input[i]);
            //}
            //return result.ToString();

            return string.Concat(input.Select((c, index) => index % 2 == 0 ? char.ToUpper(c) : c));
        }

        // Given two strings, write a method that returns one string made of two strings. First letter of new string is first letter of first string,
        // second letter of new string is first letter of second string and so on.
        public static string MixTwoStrings(string leftInput, string rightInput)
        {
            var result = new StringBuilder();

            for (int i = 0; i < (leftInput.Length >= rightInput.Length ? leftInput.Length : rightInput.Length); i++)
            {
                if (i < leftInput.Length)
                {
                    result.Append(leftInput[i]);
                }
                if (i < rightInput.Length)
                {
                    result.Append(rightInput[i]);
                }
            }

            return result.ToString();
        }

        // Given a string, write a method that counts its number of words. Assume there are no leading and trailing whitespaces and
        // there is only single whitespace between two consecutive words.
        public static int NumberOfWords(string input)
        {
            //var numberOfSpaces = 0;

            //for (int i = 0; i < input.Trim().Length; i++)
            //{
            //    if (char.IsWhiteSpace(input[i]))
            //    {
            //        numberOfSpaces++;
            //    }
            //}

            //return numberOfSpaces + 1;

            return Regex.Matches(input, @"[a-zA-Z\b]+").Count;
        }

        // Given a string, write a method that returns new string with reverted words order. Pay attention to the punctuation at the end of the sentence (period).
        public static string RevertWordsOrder(string input)
        {
            //var regex = new Regex("[a-zA-Z\\S\\b]+");
            //var words = regex.Matches(input).ToArray();
            //var result = string.Empty;

            //for (int i = words.Length - 1; i >= 0; i--)
            //{
            //    result += $" {words[i]}";
            //}

            //return result;

            return string.Join(" ", input.Split(" ").Reverse());
        }

        // Given a string and substring, write a method that returns number of occurrences of substring in the string.
        // Assume that both are case-sensitive. You may need to use library function here.
        public static int HowManyOccurrences(string input, string inputToSearch)
        {
            //var splittedWords = input.Split(" ");
            //var counter = 0;
            //for (int i = 0; i < splittedWords.Length; i++)
            //{
            //    if (splittedWords[i].Contains(inputToSearch))
            //    {
            //        counter++;
            //    }
            //}
            //return counter;

            var words = Regex.Matches(input, @"[a-zA-Z\b]+").ToList();
            var result = words.Where(w => w.ToString().Contains(inputToSearch)).ToList();
            return result.Count;
        }

        // Given a string, write a method that returns string/array of chars (ASCII characters) sorted in descending order.
        public static string SortCharactersDescending(string input)
        {
            var result = string.Concat(input.ToArray().Where(c => char.IsAscii(c)).OrderByDescending(c => c.ToString()));
            return result.Trim();
        }

        // Given a non-empty string, write a method that returns it in compressed format.
        // ex: CompressString("kkkktttrrrrrrrrrr") → "k4t3r10", CompressString("p555ppp7www") → "p153p371w3"
        public static string CompressString(string input)
        {
            var counter = 0;
            var letter = input[0];
            var result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (letter == input[i])
                {
                    counter++;
                }
                else
                {
                    result += ($"{letter}{counter}");
                    letter = input[i];
                    counter = 1; 
                }                
            }

            result += $"{letter}{counter}";
            return result;
        }
    }
}
