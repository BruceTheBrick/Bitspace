using System;
using Bitspace.Features.Constants;

namespace Bitspace.Features
{
    public class ConnectFourEngine : IConnectFourEngine
    {
        private int[][] _precomputedIndexes;
        private Piece _player;

        public void Initialize(Piece player)
        {
            _player = player;
            PrecomputedIndexes.Init();
            _precomputedIndexes = PrecomputedIndexes.GetStandardPrecomputedIndexes();
        }

        public int GetNextMove(IBoard board, Piece player)
        {
            int bestScore;
            var column = -1;

            if (_player == player)
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

                return column;
            }

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
            var score = CurrentPiecesScore(board, _player);
            score -= (int)(CurrentPiecesScore(board, GetOtherPlayer(_player)) * ConnectFourScoreConstants.MINIMIZING_PLAYER_MULTIPLIER);
            return score;
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

            // score += numOfTwos(board, _player) * ConnectFourScoreConstants.TWO_CONSECUTIVE_VALUE;
            return score;
        }

        private int GetDepth()
        {
            return 0;
        }

        private Piece GetOtherPlayer(Piece player)
        {
            return player == Piece.One
                ? Piece.Two
                : Piece.One;
        }

        private int numOfTwos(IBoard board, Piece player)
        {
            var sum = 0;
            for (var i = 0; i < PrecomputedIndexes.twoInARow.Length; i++)
            {
                var coords = IndexToCoordinates(board, i);
                if (board.GetPiece(coords.Item1, coords.Item2) != player)
                {
                    continue;
                }

                for (var j = 0; j < PrecomputedIndexes.twoInARow[i].Count; j++)
                {
                    coords = IndexToCoordinates(board, PrecomputedIndexes.twoInARow[i][j]);

                    if (board.GetPiece(coords.Item1, coords.Item2) == player)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private (int, int) IndexToCoordinates(IBoard board, int num)
        {
            var col = (num % board.Columns) - 1;
            var row = (num % board.Rows) - 1;
            return (row, col);
        }
    }
}