using System.Collections.Generic;

namespace Bitspace.Features
{
    public static class PrecomputedIndexes
    {
        public static int[][] GetStandardPrecomputedIndexes()
        {
            var board = new int[6][];
            board[0] = new[] { 1, 2, 5, 8, 5, 2, 1 };
            board[1] = new[] { 2, 5, 10, 20, 10, 5, 2 };
            board[2] = new[] { 5, 10, 20, 50, 20, 10, 5 };
            board[3] = new[] { 5, 10, 20, 50, 20, 20, 5 };
            board[4] = new[] { 2, 5, 10, 20, 10, 5, 2 };
            board[5] = new[] { 1, 2, 5, 8, 5, 2, 1 };

            return board;
        }

        public static int[][] GetRevisedPrecomputedIndexes()
        {
            var board = new int[6][];
            board[0] = new[] { 3, 4, 5, 7, 5, 4, 3 };
            board[1] = new[] { 4, 6, 8, 10, 8, 6, 4 };
            board[2] = new[] { 5, 8, 11, 13, 11, 8, 5 };
            board[3] = new[] { 5, 8, 11, 13, 11, 8, 5 };
            board[4] = new[] { 4, 6, 8, 10, 8, 6, 4 };
            board[5] = new[] { 3, 4, 5, 7, 5, 4, 3 };
            return board;
        }

        public static List<int>[] TwoInARow;
        public static List<int>[] ThreeInARow;
        public static List<int>[] FourInARow;


        public static void Init()
        {
            InitTwoInARow();
            InitThreeInARow();
            InitFourInARow();
        }

        private static void InitTwoInARow()
        {
            TwoInARow = new List<int>[41];

            for (var i = 0; i < TwoInARow.Length; i++)
            {
                TwoInARow[i] = new List<int>();

                // In bottom row
                if (i >= 35)
                {
                    TwoInARow[i].Add(i + 1);
                }

                // In left column
                else if (i % 7 == 0)
                {
                    TwoInARow[i].Add(i + 1);
                    TwoInARow[i].Add(i + 8);
                    TwoInARow[i].Add(i + 7);
                }

                // In right column
                else if (i % 7 == 6)
                {
                    TwoInARow[i].Add(i + 7);
                    TwoInARow[i].Add(i + 6);
                }
                else
                {
                    TwoInARow[i].Add(i + 1);
                    TwoInARow[i].Add(i + 8);
                    TwoInARow[i].Add(i + 7);
                    TwoInARow[i].Add(i + 6);
                }
            }
        }

        private static void InitThreeInARow()
        {
            ThreeInARow = new List<int>[40];

            for (var i = 0; i < ThreeInARow.Length; i++)
            {
                ThreeInARow[i] = new List<int>();

                // In bottom row
                if (i >= 28)
                {
                    ThreeInARow[i].Add(i + 1);
                    ThreeInARow[i].Add(i + 2);
                }
                else
                {
                    switch (i % 7)
                    {
                        // In left column
                        case 0:
                        case 1:
                            ThreeInARow[i].Add(i + 1);
                            ThreeInARow[i].Add(i + 2);

                            ThreeInARow[i].Add(i + 8);
                            ThreeInARow[i].Add(i + 16);

                            ThreeInARow[i].Add(i + 7);
                            ThreeInARow[i].Add(i + 14);
                            break;

                        // In right column
                        case 6:
                        case 5:
                            ThreeInARow[i].Add(i + 7);
                            ThreeInARow[i].Add(i + 14);

                            ThreeInARow[i].Add(i + 6);
                            ThreeInARow[i].Add(i + 12);
                            break;
                        default:
                            ThreeInARow[i].Add(i + 1);
                            ThreeInARow[i].Add(i + 2);
                            ThreeInARow[i].Add(i + 8);
                            ThreeInARow[i].Add(i + 16);
                            ThreeInARow[i].Add(i + 7);
                            ThreeInARow[i].Add(i + 14);
                            ThreeInARow[i].Add(i + 6);
                            ThreeInARow[i].Add(i + 12);
                            break;
                    }
                }
            }
        }

        private static void InitFourInARow()
        {
            FourInARow = new List<int>[39];
            for (var i = 0; i < FourInARow.Length; i++)
            {
                FourInARow[i] = new List<int>();

                switch (i)
                {
                    case <= 17 when i % 7 <= 3:
                    {
                        FourInARow[i].Add(i + 1);
                        FourInARow[i].Add(i + 2);
                        FourInARow[i].Add(i + 3);

                        FourInARow[i].Add(i + 8);
                        FourInARow[i].Add(i + 16);
                        FourInARow[i].Add(i + 24);

                        FourInARow[i].Add(i + 7);
                        FourInARow[i].Add(i + 14);
                        FourInARow[i].Add(i + 21);

                        if (i % 7 == 3)
                        {
                            FourInARow[i].Add(i + 6);
                            FourInARow[i].Add(i + 12);
                            FourInARow[i].Add(i + 18);
                        }

                        break;
                    }

                    case <= 20 when i % 7 > 3:
                        FourInARow[i].Add(i + 7);
                        FourInARow[i].Add(i + 14);
                        FourInARow[i].Add(i + 21);

                        FourInARow[i].Add(i + 6);
                        FourInARow[i].Add(i + 12);
                        FourInARow[i].Add(i + 18);
                        break;
                    case >= 21 when i % 7 <= 3:
                        FourInARow[i].Add(i + 1);
                        FourInARow[i].Add(i + 2);
                        FourInARow[i].Add(i + 3);
                        break;
                }
            }
        }
    }
}