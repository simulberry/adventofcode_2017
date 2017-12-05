using System;
using System.Linq;

namespace Adventofcode2017.Days
{
    internal class Day2 : IDayChallenge
    {
        public string Part1(string[] input)
        {
            var result = 0;
            foreach (var line in input)
            {
                var numbers = line.Split(' ').Select(l => int.Parse(l));
                var difference = numbers.Max() - numbers.Min();
                result += difference;
            }
            return result.ToString();
        }

        public string Part2(string[] input)
        {
            var result = 0;
            foreach (var line in input)
            {
                var numbers = line.Split(' ').Select(l => int.Parse(l)).ToArray();
                for (int i = 0; i < numbers.Count(); i++)
                {
                    var number = numbers[i];
                    var divisible = numbers.Where((n, index) =>
                    {
                        var sameIndex = i == index;
                        var division = (double)number / n;
                        var isDivisionEvenlyDivided = division % 1 == 0;
                        var is0 = division == 0;
                        return !sameIndex && isDivisionEvenlyDivided && !is0;
                    }).FirstOrDefault();
                    if (divisible != 0)
                    {
                        result += number / divisible;
                        break;
                    }
                }
            }
            return result.ToString();
        }
    }
}
