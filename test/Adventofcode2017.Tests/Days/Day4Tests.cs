using Adventofcode2017.Days;
using FluentAssertions;
using Xunit;

namespace Adventofcode2017.Tests.Days
{
    public class Day4Tests
    {

        [Fact]
        public void Part1()
        {
            var input = new[] { "aa bb cc dd ee", "aa bb cc dd aa", "aa bb cc dd aaa" };
            var day4 = new Day4();
            day4.Part1(input).Should().Be("2");
        }


        [Fact]
        public void Part2()
        {
            var input = new[] { "abcde fghij", "abcde xyz ecdab", "a ab abc abd abf abj" };
            var day4 = new Day4();
            day4.Part2(input).Should().Be("2");
        }
    }
}
