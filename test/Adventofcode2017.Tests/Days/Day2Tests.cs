using Adventofcode2017.Days;
using FluentAssertions;
using Xunit;

namespace Adventofcode2017.Tests.Days
{
    public class Day2Tests
    {

        [Fact]
        public void Part1()
        {
            var input = new[] { "5 1 9 5", "7 5 3" , "2 4 6 8" };
            var day2 = new Day2();
            day2.Part1(input).Should().Be("18");
        }

        [Fact]
        public void Part2()
        {
            var input = new[] { "5 9 2 8", "9 4 7 3", "3 8 6 5" };
            var day2 = new Day2();
            day2.Part2(input).Should().Be("9");
        }
    }
}
