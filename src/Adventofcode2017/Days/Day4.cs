using System;
using System.Drawing;
using System.Linq;

namespace Adventofcode2017.Days
{
    internal class Day4 : IDayChallenge
    {
        public string Part1(string[] input)
        {
            return input.Where(i =>
            {
                var words = i.Split(' ');
                return words.GroupBy(w => w).Where(g => g.Count() > 1).Count() == 0;
            }).Count().ToString();
        }

        public string Part2(string[] input)
        {
            return input.Where(i =>
            {
                var words = i.Split(' ');
                return words.GroupBy(w => new string(w.ToCharArray().OrderBy(c => c).ToArray())).Where(g => g.Count() > 1).Count() == 0;
            }).Count().ToString();
        }
    }
}
