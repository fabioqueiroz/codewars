using FluentAssertions;
using System;
using System.Collections;
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

        [Test]
        [TestCaseSource(nameof(MaxNoOfCandies))]
        public void WhenCalled_ShouldReturntrueForMaxNumber(int[] candies, int extraCandies, bool[] output)
        {
            // Arrange
            // Act
            var result = LeetCodeChallenges.KidsWithCandies(candies, extraCandies);

            // Assert
            result.Should().BeEquivalentTo(output);
        }

        private static IEnumerable MaxNoOfCandies
        {
            get
            {
                yield return new TestCaseData(new int[] { 2, 3, 5, 1, 3 }, 3, new bool[] { true, true, true, false, true });
                yield return new TestCaseData(new int[] { 4, 2, 1, 1, 2 }, 1, new bool[] { true, false, false, false, false });
                yield return new TestCaseData(new int[] { 12, 1, 12 }, 10, new bool[] { true, false, true });
            }
        }
    }
}
