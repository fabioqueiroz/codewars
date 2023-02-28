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
    }
}