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
        public void WhenCalled_ShouldAddSeparator(string input, string separator, string output)
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
        public void WhenCalled_ShouldReverseOrder(string input, string output)
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
        public void WhenCalled_ShouldFindSumOfDigits(string input, int output)
        {
            // Arrange
            // Act
            var result = Exercises.FindSumOfDigits(input);

            // Assert
            result.Should().Be(output);
        }

        [Test]
        [TestCase("modem", "MoDeM")]
        [TestCase("BookWorm", "BoOkWoRm")]
        [TestCase("Aliquam dolor nisl?", "AlIqUaM DoLoR NiSl?")]
        public void WhenCalled_ShouldMakeUppercase(string input, string output)
        {
            // Arrange
            // Act
            var result = Exercises.MakeUppercase(input);

            // Assert
            result.Should().Be(output);
        }

        [Test]
        [TestCase("aaa", "BBB", "aBaBaB")]
        [TestCase("good one", "111", "g1o1o1d one")]
        [TestCase("DoG", "ElEpHaNt", "DEolGEpHaNt")]
        public void WhenCalled_ShouldMixTwoStrings(string leftInput, string rightInput, string output)
        {
            // Arrange
            // Act
            var result = Exercises.MixTwoStrings(leftInput, rightInput);

            // Assert
            result.Should().Be(output);
        }

        [Test]
        [TestCase("This is sample sentence", 4)]
        [TestCase("OK", 1)]
        public void WhenCalled_ShouldReturnNumberOfWords(string input, int output)
        {
            // Arrange
            // Act
            var result = Exercises.NumberOfWords(input);

            // Assert
            result.Should().Be(output);
        }

        [Test]
        [TestCase("John Doe.", "Doe. John")]
        [TestCase("A, B. C", "C B. A,")]
        public void WhenCalled_ShouldRevertWordsOrder(string input, string output)
        {
            // Arrange
            // Act
            var result = Exercises.RevertWordsOrder(input);

            // Assert
            result.Should().Be(output);
        }

        [Test]
        [TestCase("do it now", "do", 1)]
        [TestCase("empty", "d", 0)]
        public void WhenCalled_ShouldReturnHowManyOccurrences(string leftInput, string rightInput, int output)
        {
            // Arrange
            // Act
            var result = Exercises.HowManyOccurrences(leftInput, rightInput);

            // Assert
            result.Should().Be(output);
        }

        [Test]
        [TestCase("onomatopoeia", "tpoooonmieaa")]
        [TestCase("fohjwf42os", "wsoojhff42")]
        [TestCase("Thi2 12  5@mpl3 Str!nG~", "TtSrpnmlihG53221~@!")]
        //[TestCase("Thi2 12  5@mpl3 Str!nG~", "~trpnmlihTSG@53221!")]
        public void WhenCalled_ShouldSortCharactersDescending(string input, string output)
        {
            // Arrange
            // Act
            var result = Exercises.SortCharactersDescending(input);

            // Assert
            result.Should().Be(output);
        }

        [Test]
        [TestCase("kkkktttrrrrrrrrrr", "k4t3r10")]
        [TestCase("p555ppp7www", "p153p371w3")]
        public void WhenCalled_ShouldCompressString(string input, string output)
        {
            // Arrange
            // Act
            var result = Exercises.CompressString(input);

            // Assert
            result.Should().Be(output);
        }
    }
}
