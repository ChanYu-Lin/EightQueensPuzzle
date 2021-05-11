using System;
using System.Linq;

namespace EightQueensPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            new Answer().Do();
            Console.Read();
        }
    }

    public class Answer
    {
        private const int BOARD_LENGTH = 8;
        private const int QUEEN_COUNT = 8;
        private int Count = 0;
        public void Do()
        {
            Do(0, new ChessPoint[QUEEN_COUNT]);
        }

        private void Do(int x, ChessPoint[] queenPoints)
        {
            if (x < BOARD_LENGTH)
            {
                for (var y = 0; y < BOARD_LENGTH; y++)
                {
                    ChessPoint newQueen = new ChessPoint(x, y);

                    if (IsValid(queenPoints, newQueen))
                    {
                        ChessPoint[] queens = queenPoints.ToArray();
                        queens[x] = newQueen;
                        Do(x + 1, queens);
                    }
                }
            }
            else
                Print(queenPoints);
        }

        private bool IsValid(ChessPoint[] queens, ChessPoint newQueen)
        {
            foreach (var queen in queens)
            {
                if (queen != null)
                {
                    int diffX = queen.X - newQueen.X;
                    int diffY = queen.Y - newQueen.Y;

                    if (diffX == 0 || diffY == 0)
                        return false;
                    else if (Math.Abs((double)(queen.Y - newQueen.Y) / (queen.X - newQueen.X)) == 1)
                        return false;
                }
            }

            return true;
        }

        private void Print(ChessPoint[] queens)
        {
            Console.WriteLine($"=========={++Count}==========");
            for (var i = 0; i < BOARD_LENGTH; i++)
            {
                for (var j = 0; j < BOARD_LENGTH; j++)
                {
                    if (queens.Where(item => item.X == i && item.Y == j).Count() == 0)
                        Console.Write('.');
                    else
                        Console.Write('Q');
                }
                Console.WriteLine();
            }
        }

        private class ChessPoint
        {
            public int X { get; }
            public int Y { get; }
            public ChessPoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
