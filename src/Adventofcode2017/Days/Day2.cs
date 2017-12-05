using System;
using System.Linq;

namespace Adventofcode2017.Days
{
    internal class Day2 : IDayChallenge
    {
        public string Part1(string[] input)
        {
            return input.Sum(l =>
                {
                    var numbers = l.Split(' ').Select(int.Parse);
                    return numbers.Max() - numbers.Min();
                }
            ).ToString();
        }

        public string Part2(string[] input)
        {
            return input.Sum(l =>
            {
                var numbers = l.Split(' ').Select(int.Parse);
                return numbers.Sum(n1 => numbers.Where(n2 => n1 != n2 && n1 % n2 == 0).Sum(n2 => n1 / n2));
            }).ToString();
        }
    }
}
