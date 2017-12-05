using Adventofcode2017.Days;
using System;
using System.IO;

namespace Adventofcode2017
{
    class Program
    {
        private static int DayIndex = 0;
        private static int PartIndex = 1;
        private static int InputIndex = 2;
        private static int FileOptionIndex = 2;
        private static int FileIndex = 3;
        static void Main(string[] args)
        {
            if (args.Length < 3
                || !int.TryParse(args[DayIndex], out int day)
                || !int.TryParse(args[PartIndex], out int part)
                || part < 1 || part > 2)
            {
                throw new ArgumentException("Enter day number, part number (1 or 2), then input string or `-file filename`");
            }

            if (args.Length > 5 && args[FileOptionIndex] != "-file")
            {
                throw new ArgumentException("Use -file filename to input a file");
            }

            var fileOption = args[FileOptionIndex];
            string[] input;
            if (fileOption == "-file")
            {
                input = File.ReadAllLines(args[FileIndex]);
            }
            else
            {
                input = new string[] { args[InputIndex] };
            }

            Console.WriteLine($"Result: {GetChallengeResult(day, part, input)}");
        }

        private static string GetChallengeResult(int day, int part, string[] input)
        {
            IDayChallenge challenge;
            switch (day)
            {
                case 1:
                    challenge = new Day1();
                    break;
                case 2:
                    challenge = new Day2();
                    break;
                case 3:
                    challenge = new Day3();
                    break;
                default:
                    return $"Day {day} not found";
            }
            return part == 1 ? challenge.Part1(input) : challenge.Part2(input);
        }
    }
}
