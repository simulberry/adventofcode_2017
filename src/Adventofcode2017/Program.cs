using Adventofcode2017.Days;
using System;

namespace Adventofcode2017
{
    class Program
    {
        private static int DayIndex = 0;
        private static int PartIndex = 1;
        private static int InputIndex = 2;
        static void Main(string[] args)
        {
            if (args.Length != 3
                || !int.TryParse(args[DayIndex], out int day)
                || !int.TryParse(args[PartIndex], out int part)
                || part < 1 || part > 2)
            {
                throw new ArgumentException("Enter day number, part number (1 or 2), then input");
            }

            Console.WriteLine($"Result: {GetChallengeResult(day, part, args[InputIndex])}");
        }

        private static string GetChallengeResult(int day, int part, string input)
        {
            IDayChallenge challenge;
            switch (day)
            {
                case 1:
                    challenge = new Day1();
                    break;
                default:
                    return $"Day {day} not found";
            }
            if (part == 1)
            {
                return challenge.Part1(input);
            }
            else
            {
                return challenge.Part2(input);
            }
        }
    }
}
