using Bogus;
using FluentAssertions;
using System.Runtime.CompilerServices;

namespace CodeWars.Tests
{
    public class ChallengeTests
    {
        private static readonly Randomizer _randomizer = new();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void WhenCalled_UsersWhoLiked_ShouldBeDisplayed(int numberOfnames)
        {
            // Arrange
            var names = _randomizer.WordsArray(numberOfnames);

            // Act
            var result = Challenges.FindWhoLikesThePost(names);

            // Assert
            if (numberOfnames == 0)
            {
                result.Should().Be("no one likes this");
            }

            if (numberOfnames == 1)
            {
                result.Should().Be($"{names[0]} likes this");
            }

            if (numberOfnames == 2)
            {
                result.Should().Be($"{names[0]} and {names[1]} like this");
            }

            if (numberOfnames == 3)
            {
                result.Should().Be($"{names[0]}, {names[1]} and {names[2]} like this");
            }
        }

        [Test]
        [TestCase("Negative case #1.", false)]
        [TestCase("The quick brown fox jumps over the lazy dog.", true)]
        public void WhenCalled_ShouldValidate_IfItIsPangram(string input, bool isCorrect)
        {
            // Arrange
            // Act
            var result = Challenges.IsPangram(input);

            // Assert
            result.Should().Be(isCorrect);
        }

        [Test]
        [TestCase(12)]
        [TestCase(16)]
        [TestCase(25)]
        [TestCase(13)]
        public void WhenCalled_FindTheDivisors(int number)
        {
            // Arrange
            var case12Result = new int[] { 2, 3, 4, 6 };
            var case16Result = new int[] { 2, 4, 8 };
            var case25Result = new int[] { 5 };

            // Act
            var result = Challenges.Divisors(number);

            // Assert
            if (number == 12) 
            {
                result.Should().BeEquivalentTo(case12Result);
            }

            if (number == 16)
            {
                result.Should().BeEquivalentTo(case16Result);
            }

            if (number == 25)
            {
                result.Should().BeEquivalentTo(case25Result);
            }

            if (number == 13)
            {
                result.Should().BeNull();
            }
        }

        [Test]
        [TestCase("Dermatoglyphics", true)]
        [TestCase("moose", false)]
        [TestCase("aba", false)]
        [TestCase("", true)]
        public void WhenCalled_ShouldValidate_IfItIsIsogram(string input, bool isCorrect)
        {
            // Arrange
            // Act
            var result = Challenges.IsIsogram(input);

            // Assert
            result.Should().Be(isCorrect);
        }

        [Test]
        [TestCase("1234", true)]
        [TestCase("12345", false)]
        [TestCase("123456", true)]
        [TestCase("a234", false)]
        [TestCase("-1234", false)]
        [TestCase("1.234", false)]
        [TestCase("1234" + "\n", false)]
        public void WhenCalled_ShouldValidate_IfPinIsCorrect(string input, bool isCorrect)
        {
            // Arrange
            // Act
            var result = Challenges.ValidatePin(input);

            // Assert
            result.Should().Be(isCorrect);
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 8)]
        [TestCase(3, 27)]
        [TestCase(4, 64)]
        public void WhenCalled_ShouldCalculate_SumOfOddNUmbers(int rowNumber, int total)
        {
            // Arrange
            // Act
            var result = Challenges.RowSumOddNumbers(rowNumber);

            // Assert
            result.Should().Be(total); 
        }

        [Test]
        [TestCase(1500, 5, 100, 5000, 15)]
        [TestCase(1500000, 2.5, 10000, 2000000, 10)]
        [TestCase(1500000, 0.25, 1000, 2000000, 94)]
        public void WhenCalled_ShouldCalculate_PopulationGrowth(int p0, double percent, int aug, int p, int years)
        {
            // Arrange
            // Act
            var result = Challenges.NbYear(p0, percent, aug, p);

            // Assert
            result.Should().Be(years);
        }
    }
}