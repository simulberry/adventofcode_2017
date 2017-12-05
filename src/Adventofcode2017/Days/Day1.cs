using System.Linq;

namespace Adventofcode2017.Days
{
    internal class Day1 : IDayChallenge
    {
        /// <summary>
        /// The captcha requires you to review a sequence of digits (your puzzle input) 
        /// and find the sum of all digits that match the next digit in the list. The list is circular, 
        /// so the digit after the last digit is the first digit in the list.
        /// For example:
        /// 1122 produces a sum of 3 (1 + 2) because the first digit(1) matches the second digit and the third digit(2) matches the fourth digit.
        /// 1111 produces 4 because each digit (all 1) matches the next.
        /// 1234 produces 0 because no digit matches the next.
        /// 91212129 produces 9 because the only digit that matches the next one is the last digit, 9.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Part1(string[] input)
        {
            var captcha = input[0] + input[0][0];
            var pairs = captcha.Where((e, i) => i < captcha.Length - 1)
                .Select((e, i) => new { A = e, B = captcha[i + 1] })
                .Where(pair => pair.A == pair.B).Sum(pair => int.Parse(pair.A.ToString()));

            return pairs.ToString();
        }

        public string Part2(string[] input)
        {
            var captcha = input[0];
            var pairs = captcha.Where((e, i) => i < captcha.Length)
                .Select((e, i) => new { A = e, B = captcha[GetIndexHalfwayAround(captcha.Length, i)] })
                .Where(pair => pair.A == pair.B).Sum(pair => int.Parse(pair.A.ToString()));

            return pairs.ToString();
        }

        private static int GetIndexHalfwayAround(int size, int currentIndex)
        {
            var distance = size / 2;
            var currentIndexAndHalf = currentIndex + distance;
            return currentIndexAndHalf % size;
        }

    }
}
