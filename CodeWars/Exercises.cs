using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
