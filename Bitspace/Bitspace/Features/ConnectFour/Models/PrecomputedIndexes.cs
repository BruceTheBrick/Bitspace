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
    }
}