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
        [TestCase("Negative")]
        [TestCase("Positive")]
        public void WhenCalled_ShouldValidate_IfItIsPangram(string input)
        {
            // Arrange
            var str = string.Empty;

            if (input.Equals("Negative"))
            {
                str = "Negative case #1.";
            }

            if (input.Equals("Positive"))
            {
                str = "The quick brown fox jumps over the lazy dog.";
            }

            // Act
            var result = Challenges.IsPangram(str);

            // Assert
            if (input.Equals("Negative"))
            {
                result.Should().BeFalse();
            }

            if (input.Equals("Positive"))
            {
                result.Should().BeTrue();
            }
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
        [TestCase("Dermatoglyphics")]
        [TestCase("moose")]
        [TestCase("aba")]
        [TestCase("")]
        public void WhenCalled_ShouldValidate_IfItIsIsogram(string input)
        {
            // Arrange
            // Act
            var result = Challenges.IsIsogram(input);

            // Assert
            if (input.Equals("Dermatoglyphics") || input.Equals(""))
            {
                result.Should().BeTrue();
            }
            else
            {
                result.Should().BeFalse();
            }
        }

        [Test]
        [TestCase("1234")]
        [TestCase("12345")]
        [TestCase("123456")]
        [TestCase("a234")]
        [TestCase("-1234")]
        [TestCase("1.234")]
        [TestCase("1234" + "\n")]
        public void WhenCalled_ShouldValidate_IfPinIsCorrect(string input)
        {
            // Arrange
            // Act
            var result = Challenges.ValidatePin(input);

            // Assert
            if (input.Equals("1234") || input.Equals("123456"))
            {
                result.Should().BeTrue();
            }
            else
            {
                result.Should().BeFalse();
            }
        }
    }
}