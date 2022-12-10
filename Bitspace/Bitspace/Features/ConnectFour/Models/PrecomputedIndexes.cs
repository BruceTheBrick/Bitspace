using System.Collections.Generic;

namespace Bitspace.Features
{
    public static class PrecomputedIndexes
    {
        public static int[][] GetStandardPrecomputedIndexes()
        {
            var board = new int[6][];
            board[0] = new[] { 1, 2, 5, 10, 5, 2, 1 };
            board[1] = new[] { 2, 5, 10, 20, 10, 5, 2 };
            board[2] = new[] { 5, 10, 50, 50, 50, 10, 5 };
            board[3] = new[] { 5, 10, 50, 50, 50, 10, 5 };
            board[4] = new[] { 2, 5, 10, 20, 10, 5, 2 };
            board[5] = new[] { 1, 2, 5, 10, 5, 2, 1 };

            return board;
        }

        public static List<int>[] twoInARow;
        public static List<int>[] threeInARow;
        public static List<int>[] fourInARow;


        public static void Init()
        {
            InitTwoInARow();
            InitThreeInARow();
            InitFourInARow();
        }

        public static void InitTwoInARow()
        {
            twoInARow = new List<int>[41];

            for (int i = 0; i < twoInARow.Length; i++)
            {

                twoInARow[i] = new List<int>();

                //In bottom row
                if (i >= 35)
                {
                    twoInARow[i].Add(i + 1);
                }

                //In left column
                else if (i % 7 == 0)
                {
                    twoInARow[i].Add(i + 1);
                    twoInARow[i].Add(i + 8);
                    twoInARow[i].Add(i + 7);
                }

                //In right column
                else if (i % 7 == 6)
                {
                    twoInARow[i].Add(i + 7);
                    twoInARow[i].Add(i + 6);
                }
                else
                {
                    twoInARow[i].Add(i + 1);
                    twoInARow[i].Add(i + 8);
                    twoInARow[i].Add(i + 7);
                    twoInARow[i].Add(i + 6);
                }
            }
        }

        public static void InitThreeInARow()
        {
            threeInARow = new List<int>[40];

            for (int i = 0; i < threeInARow.Length; i++)
            {

                threeInARow[i] = new List<int>();

                //In bottom row
                if (i >= 28)
                {
                    threeInARow[i].Add(i + 1);
                    threeInARow[i].Add(i + 2);
                }

                //In left column
                else if (i % 7 == 0 || i % 7 == 1)
                {
                    threeInARow[i].Add(i + 1);
                    threeInARow[i].Add(i + 2);

                    threeInARow[i].Add(i + 8);
                    threeInARow[i].Add(i + 16);

                    threeInARow[i].Add(i + 7);
                    threeInARow[i].Add(i + 14);
                }

                //In right column
                else if (i % 7 == 6 || i % 7 == 5)
                {
                    threeInARow[i].Add(i + 7);
                    threeInARow[i].Add(i + 14);

                    threeInARow[i].Add(i + 6);
                    threeInARow[i].Add(i + 12);
                }

                else
                {
                    threeInARow[i].Add(i + 1);
                    threeInARow[i].Add(i + 2);
                    threeInARow[i].Add(i + 8);
                    threeInARow[i].Add(i + 16);
                    threeInARow[i].Add(i + 7);
                    threeInARow[i].Add(i + 14);
                    threeInARow[i].Add(i + 6);
                    threeInARow[i].Add(i + 12);
                }

            }
        }

        public static void InitFourInARow()
        {
            fourInARow = new List<int>[39];

            for (int i = 0; i < fourInARow.Length; i++)
            {

                fourInARow[i] = new List<int>();

                if (i <= 17 && i % 7 <= 3)
                {
                    fourInARow[i].Add(i + 1);
                    fourInARow[i].Add(i + 2);
                    fourInARow[i].Add(i + 3);

                    fourInARow[i].Add(i + 8);
                    fourInARow[i].Add(i + 16);
                    fourInARow[i].Add(i + 24);

                    fourInARow[i].Add(i + 7);
                    fourInARow[i].Add(i + 14);
                    fourInARow[i].Add(i + 21);

                    if (i % 7 == 3)
                    {
                        fourInARow[i].Add(i + 6);
                        fourInARow[i].Add(i + 12);
                        fourInARow[i].Add(i + 18);
                    }
                }
                else if (i <= 20 && i % 7 > 3)
                {
                    fourInARow[i].Add(i + 7);
                    fourInARow[i].Add(i + 14);
                    fourInARow[i].Add(i + 21);

                    fourInARow[i].Add(i + 6);
                    fourInARow[i].Add(i + 12);
                    fourInARow[i].Add(i + 18);
                }
                else if (i >= 21 && i % 7 <= 3)
                {
                    fourInARow[i].Add(i + 1);
                    fourInARow[i].Add(i + 2);
                    fourInARow[i].Add(i + 3);
                }
            }
        }
    }
}