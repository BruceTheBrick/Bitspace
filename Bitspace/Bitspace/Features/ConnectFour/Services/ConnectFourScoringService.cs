using System;
using System.Collections.Generic;
using Bitspace.Features.Constants;
using System.Linq;
using Xamarin.Essentials;

namespace Bitspace.Features
{
    public class ConnectFourScoringService : IConnectFourScoringService
    {
        private readonly int[][] _precomputedIndexes;
        private Piece _maximisingPlayer;

        public ConnectFourScoringService()
        {
            _precomputedIndexes = GetPrecomputedIndexes();
        }

        public void SetMaximisingPlayer(Piece player)
        {
            _maximisingPlayer = player;
        }

        public int GetScore(IBoard board)
        {
            var maxScore = GetBaseScore(board, _maximisingPlayer);
            var minScore = GetBaseScore(board, _maximisingPlayer.GetOpponent()) * -1;

            maxScore += GetPairsScore(board, _maximisingPlayer);
            minScore += (int)(GetPairsScore(board, _maximisingPlayer.GetOpponent()) * -1 * 1.5);

            maxScore += GetTriadsScore(board, _maximisingPlayer);
            minScore += (int)(GetTriadsScore(board, _maximisingPlayer.GetOpponent()) * -1 * 1.5);

            maxScore += GetWinScore(board, _maximisingPlayer);
            minScore += (int)(GetWinScore(board, _maximisingPlayer.GetOpponent()) * -1 * 1.5);

            if (IsWinner(board, _maximisingPlayer))
            {
                maxScore = int.MaxValue;
            }

            if (IsWinner(board, _maximisingPlayer.GetOpponent()))
            {
                minScore = int.MinValue;
            }

            return maxScore + minScore;
        }

        private int GetBaseScore(IBoard board, Piece player)
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

        private int GetPairsScore(IBoard board, Piece player)
        {
            var pairs = FindConsecutivePieces(board, player, 2);
            return pairs.Count * 3;
        }

        private int GetTriadsScore(IBoard board, Piece player)
        {
            var triads = FindConsecutivePieces(board, player, 3);
            return triads.Count * 5;
        }

        private int GetWinScore(IBoard board, Piece player)
        {
            var isWinner = FindConsecutivePieces(board, player, 4).Count > 0;
            return isWinner ? int.MaxValue : 0;
        }

        private bool IsWinner(IBoard board, Piece player)
        {
            return FindConsecutivePieces(board, player, 4).Count > 0;
        }

        private List<List<Piece>> FindConsecutivePieces(IBoard board, Piece player, int numPieces)
        {
            var pairs = new List<List<Piece>>();
            var directions = GetDirectionVectors();
            foreach (var direction in directions)
            {
                for (var row = 0; row < board.Rows; row++)
                {
                    for (var col = 0; col < board.Columns; col++)
                    {
                        var pieces = GetSection(board, row, col, direction.verticalVector, direction.horizontalVector, numPieces);
                        if (pieces.All(p => p == player))
                        {
                            pairs.Add(pieces.ToList());
                        }
                    }
                }
            }

            return pairs;
        }

        private IEnumerable<(int verticalVector, int horizontalVector)> GetDirectionVectors()
        {
            var directions = new List<(int, int)>
            {
                (-1, 0), // up
                (1, 0), // down
                (0, -1), // left
                (0, 1), // right
                (-1, -1), // up-left
                (1, 1), // down-right
                (-1, 1), // up-right
                (1, -1), // down-left
            };
            return directions;
        }

        private IList<Piece> GetSection(IBoard board, int row, int column, int rowIncrement, int colIncrement, int numPieces)
        {
            var pieces = new List<Piece>();
            for (var i = 0; i < numPieces; i++)
            {
                pieces.Add(board.GetPiece(row + (i * rowIncrement), column + (i * colIncrement)));
            }

            return pieces;
        }

        private int[][] GetPrecomputedIndexes()
        {
            var indexes = new int[6][];
            indexes[0] = new[] { 3, 4, 5, 7, 5, 4, 3 };
            indexes[1] = new[] { 4, 6, 8, 10, 8, 6, 4 };
            indexes[2] = new[] { 5, 8, 11, 13, 11, 8, 5 };
            indexes[3] = new[] { 5, 8, 11, 13, 11, 8, 5 };
            indexes[4] = new[] { 4, 6, 8, 10, 8, 6, 4 };
            indexes[5] = new[] { 3, 4, 5, 7, 5, 4, 3 };
            return indexes;
        }
    }
}