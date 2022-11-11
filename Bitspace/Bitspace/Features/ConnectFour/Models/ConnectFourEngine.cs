using System;

namespace Bitspace.Features
{
    public class ConnectFourEngine : IConnectFourEngine
    {
        private int[][] _precomputedIndexes;
        private Piece _player;

        public void Initialize(Piece player)
        {
            _player = player;
            _precomputedIndexes = PrecomputedIndexes.GetStandardPrecomputedIndexes();
        }

        public int GetNextMove(IBoard board, Piece player)
        {
            var isMaximising = player == _player;
            var bestScore = 0;
            var column = -1;

            if (isMaximising)
            {
                bestScore = int.MinValue;
                for (var i = 0; i < board.Columns; i++)
                {
                    if (board.IsColumnFull(i))
                    {
                        continue;
                    }

                    board.PlacePiece(i, player);
                    var score = Mini(board, GetDepth(), int.MinValue, int.MaxValue, GetOtherPlayer(player));
                    if (score >= bestScore)
                    {
                        bestScore = score;
                        column = i;
                    }

                    board.Undo();
                }
            }
            else
            {
                bestScore = int.MaxValue;
                for (var i = 0; i < board.Columns; i++)
                {
                    if (board.IsColumnFull(i))
                    {
                        continue;
                    }

                    board.PlacePiece(i, player);
                    var score = Max(board, GetDepth(), int.MinValue, int.MaxValue, player);
                    if (score <= bestScore)
                    {
                        bestScore = score;
                        column = i;
                    }

                    board.Undo();
                }
            }

            return column;
        }

        public int Mini(IBoard board, int depth, int alpha, int beta, Piece player)
        {
            if (depth == 0 || board.IsFull())
            {
                return Evaluate(board, depth);
            }

            var min = int.MinValue;
            for (var i = 0; i < board.Columns; i++)
            {
                if (board.IsColumnFull(i))
                {
                    continue;
                }

                board.PlacePiece(i, player);
                var score = Max(board, depth - 1, alpha, beta, GetOtherPlayer(player));
                min = Math.Min(min, score);
                beta = Math.Min(beta, min);
                board.Undo();
                if (beta >= alpha)
                {
                    break;
                }
            }

            return min;
        }

        public int Max(IBoard board, int depth, int alpha, int beta, Piece player)
        {
            if (depth == 0 || board.IsFull())
            {
                return Evaluate(board, depth);
            }

            var max = int.MinValue;
            for (var i = 0; i < board.Columns; i++)
            {
                if (board.IsColumnFull(i))
                {
                    continue;
                }

                board.PlacePiece(i, player);

                var score = Mini(board, depth - 1, alpha, beta, GetOtherPlayer(player));
                max = Math.Max(max, score);
                alpha = Math.Max(alpha, max);
                board.Undo();
                if (beta <= alpha)
                {
                    break;
                }
            }

            return max;
        }

        public int Evaluate(IBoard board, int depth)
        {
            var maximisingPlayerScore = CurrentPiecesScore(board, _player);
            var minimizingPlayerScore = CurrentPiecesScore(board, GetOtherPlayer(_player));
            return maximisingPlayerScore - minimizingPlayerScore;
        }

        private int CurrentPiecesScore(IBoard board, Piece player)
        {
            var score = 0;
            for (var x = 0; x < board.Rows; x++)
            {
                for (var y = 0; y < board.Columns; y++)
                {
                    if (board.GetPiece(x, y) == player)
                    {
                        score += _precomputedIndexes[x][y];
                    }
                }
            }

            return score;
        }

        private int GetDepth()
        {
            return 1;
        }

        private Piece GetOtherPlayer(Piece player)
        {
            return player == Piece.One
                ? Piece.Two
                : Piece.One;
        }
    }
}