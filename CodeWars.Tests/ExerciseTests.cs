using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using System.Runtime.CompilerServices;

namespace CodeWars.Tests
{
    public class ExerciseTests
    {
        [Test]
        [TestCase("ABCD", "^", "A^B^C^D")]
        [TestCase("chocolate", "-", "c-h-o-c-o-l-a-t-e")]
        public void WhenCalled_ShouldAddSeparatorSuccessfully(string input, string separator, string output)
        {
            // Arrange
            // Act
            var result = Exercises.AddSeparator(input, separator);

            // Assert
            result.Should().Be(output);
        }

        [Test]
        [TestCase("qwerty", "ytrewq")]
        [TestCase("oe93 kr", "rk 39eo")]
        public void WhenCalled_ShouldReverseOrderSuccessfully(string input, string output)
        {
            // Arrange
            // Act
            var result = Exercises.ReverseOrder(input);

            // Assert
            result.Should().Be(output);
        }

        [Test]
        [TestCase("1q2w3e", 6)]
        [TestCase("L0r3m.1p5um", 9)]
        [TestCase("", 0)]
        public void WhenCalled_ShouldFindSumOfDigitsSuccessfully(string input, int output)
        {
            // Arrange
            // Act
            var result = Exercises.FindSumOfDigits(input);

            // Assert
            result.Should().Be(output);
        }
    }
}
