using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.Tests
{
    [TestOf(nameof(LeetCodeChallenges))]
    public class LeetCodeChalengeTests
    {
        [Test]
        [TestCase("abc", "pqr", "apbqcr")]
        [TestCase("abcd", "pq", "apbqcd")]
        [TestCase("ab", "pqrs", "apbqrs")]
        public void WhenCalled_ShouldMergeAlternately(string word1, string word2, string output)
        {
            // Arrange
            // Act
            var result = LeetCodeChallenges.MergeAlternately(word1, word2);

            // Assert
            result.Should().Be(output);
        }

        [Test]
        [TestCase("ABCABC", "ABC", "ABC")]
        [TestCase("ABABAB", "ABAB", "AB")]
        [TestCase("ABABABAB", "ABAB", "ABAB")]
        [TestCase("TAUXXTAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXXTAUXX", "TAUXXTAUXX")]
        [TestCase("TAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXX")]
        [TestCase("ABCDEF", "ABC", "")]
        [TestCase("LEET", "CODE", "")]
        [TestCase("LEET", "CODETEST", "")]
        [TestCase("ABABAB", "ABA", "")]
        public void WhenCalled_ShouldFindTheGreatestCommonDivisor(string word1, string word2, string output)
        {
            // Arrange
            // Act
            var result = LeetCodeChallenges.GcdOfStrings(word1, word2);

            // Assert
            result.Should().Be(output);
        }
    }
}
