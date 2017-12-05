using Adventofcode2017.Days;
using FluentAssertions;
using Xunit;

namespace Adventofcode2017.Tests.Days
{
    public class Day3Tests
    {

        [Theory]
        [InlineData("1", "0")]
        [InlineData("12", "3")]
        [InlineData("23", "2")]
        [InlineData("1024", "31")]
        public void Part1(string input, string expected)
        {
            var day3 = new Day3();
            day3.Part1(new[] { input }).Should().Be(expected);
        }


        [Theory]
        [InlineData("122", "133")]
        [InlineData("133", "142")]
        [InlineData("2", "4")]
        [InlineData("11", "23")]
        public void Part2(string input, string expected)
        {
            var day3 = new Day3();
            day3.Part2(new[] { input }).Should().Be(expected);
        }
    }
}
