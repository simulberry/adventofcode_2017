using Adventofcode2017.Days;
using FluentAssertions;
using Xunit;

namespace Adventofcode2017.Tests.Days
{
    public class Day1Tests
    {
        [Theory]
        [InlineData("1122", "3")]
        [InlineData("1111", "4")]
        [InlineData("1234", "0")]
        [InlineData("91212129", "9")]
        public void Part1(string input, string expected)
        {
            var day1 = new Day1();
            day1.Part1(new[] { input }).Should().Be(expected);
        }

        [Theory]
        [InlineData("1212", "6")]
        [InlineData("1221", "0")]
        [InlineData("123425", "4")]
        [InlineData("123123", "12")]
        [InlineData("12131415", "4")]
        public void Part2(string input, string expected)
        {
            var day1 = new Day1();
            day1.Part2(new[] { input }).Should().Be(expected);
        }
    }
}
