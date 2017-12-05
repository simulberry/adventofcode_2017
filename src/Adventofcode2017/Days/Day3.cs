using System;
using System.Drawing;

namespace Adventofcode2017.Days
{
    internal class Day3 : IDayChallenge
    {
        public string Part1(string[] input)
        {
            var value = int.Parse(input[0]);
            var sideSize = Convert.ToInt32(Math.Ceiling(Math.Sqrt(value))) + 1;
            var spiral = new Spiral(sideSize % 2 == 0 ? sideSize + 1 : sideSize);
            return spiral.FindDistance(value).ToString();
        }

        public string Part2(string[] input)
        {
            var valueToFind = int.Parse(input[0]);
            // lack of time here...
            var sideSize = 2049;
            var cells = new int[sideSize][];
            for (int i = 0; i < sideSize; i++)
            {
                cells[i] = new int[sideSize];
            }
            var center = new Point(sideSize / 2, sideSize / 2);
            cells[center.X][center.Y] = 1;
            var current = new Point(center.X + 1, center.Y); ;
            var currentDirection = Spiral.Direction.Right;
            while (true)
            {
                var value = GetSurroundingSum(cells, current);
                if (value > valueToFind)
                {
                    return value.ToString();
                }
                cells[current.X][current.Y] = value;
                var nextDirections = Spiral.PreferedDirectionsFrom(currentDirection);
                foreach (var direction in nextDirections)
                {
                    if (direction == Spiral.Direction.Right && cells[current.X + 1][current.Y] == 0)
                    {
                        currentDirection = direction;
                        current = new Point(current.X + 1, current.Y);
                        break;
                    }

                    if (direction == Spiral.Direction.Up && cells[current.X][current.Y + 1] == 0)
                    {
                        currentDirection = direction;
                        current = new Point(current.X, current.Y + 1);
                        break;
                    }

                    if (direction == Spiral.Direction.Left && cells[current.X - 1][current.Y] == 0)
                    {
                        currentDirection = direction;
                        current = new Point(current.X - 1, current.Y);
                        break;
                    }

                    if (direction == Spiral.Direction.Down && cells[current.X][current.Y - 1] == 0)
                    {
                        currentDirection = direction;
                        current = new Point(current.X, current.Y - 1);
                        break;
                    }
                }
            }
        }

        private static int GetSurroundingSum(int[][] cells, Point point)
        {
            var result = 0;
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    result += cells[point.X + x][point.Y + y];
                }
            }
            return result;
        }


        private class Spiral
        {
            private readonly Point center;
            private readonly int[][] cells;
            public enum Direction
            {
                Right,
                Left,
                Up,
                Down
            }
            public Spiral(int sideSize)
            {
                cells = new int[sideSize][];
                for (int i = 0; i < sideSize; i++)
                {
                    cells[i] = new int[sideSize];
                }
                center = new Point(sideSize / 2, sideSize / 2);
                Init();
            }

            public int FindDistance(int value)
            {
                bool found = false;
                int x, y = 0;
                for (x = 0; x < cells.Length && !found; x++)
                {
                    for (y = 0; y < cells.Length && !found; y++)
                    {
                        if (this.cells[x][y] == value)
                        {
                            found = true;
                        }
                    }
                }
                return Math.Abs(x - 1 - center.X) + Math.Abs(y - 1 - center.Y);
            }

            private void Init()
            {
                var current = center;
                var value = 1;
                var currentDirection = Direction.Down;
                while (value < cells.Length * cells.Length)
                {
                    cells[current.X][current.Y] = value;
                    value++;
                    var nextDirections = PreferedDirectionsFrom(currentDirection);
                    foreach (var direction in nextDirections)
                    {
                        if (direction == Direction.Right && cells[current.X + 1][current.Y] == 0)
                        {
                            currentDirection = direction;
                            current = new Point(current.X + 1, current.Y);
                            break;
                        }

                        if (direction == Direction.Up && cells[current.X][current.Y + 1] == 0)
                        {
                            currentDirection = direction;
                            current = new Point(current.X, current.Y + 1);
                            break;
                        }

                        if (direction == Direction.Left && cells[current.X - 1][current.Y] == 0)
                        {
                            currentDirection = direction;
                            current = new Point(current.X - 1, current.Y);
                            break;
                        }

                        if (direction == Direction.Down && cells[current.X][current.Y - 1] == 0)
                        {
                            currentDirection = direction;
                            current = new Point(current.X, current.Y - 1);
                            break;
                        }
                    }
                }
            }

            internal static Direction[] PreferedDirectionsFrom(Direction currentDirection)
            {
                switch (currentDirection)
                {
                    case Direction.Right:
                        return new[] { Direction.Up, Direction.Right };
                    case Direction.Up:
                        return new[] { Direction.Left, Direction.Up };
                    case Direction.Left:
                        return new[] { Direction.Down, Direction.Left };
                    case Direction.Down:
                        return new[] { Direction.Right, Direction.Down };
                    default:
                        throw new ArgumentException("Direction unknown");
                }
            }
        }
    }
}
