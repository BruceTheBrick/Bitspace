using System;
using System.Collections.Generic;
using Bitspace.Features.Constants;
using System.Linq;
using Xamarin.Essentials;

namespace Bitspace.Features
{
    public class ConnectFourScoringService2 : IConnectFourScoringService
    {
        private readonly int[][] _precomputedIndexes;
        private Piece _maximisingPlayer;

        public ConnectFourScoringService2()
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

            maxScore += GetConsecutivePiecesScore(board, _maximisingPlayer);
            minScore += (int)Math.Ceiling(GetConsecutivePiecesScore(board, _maximisingPlayer.GetOpponent()) * -1 * 1.5);
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

        private int GetConsecutivePiecesScore(IBoard board, Piece player)
        {
            var pairs = FindConsecutivePairs(board, player);
            return pairs.Count * 2;
        }

        private List<List<Piece>> FindConsecutivePairs(IBoard board, Piece player)
        {
            var pairs = new List<List<Piece>>();
            var directions = GetPairsDirections();
            foreach (var direction in directions)
            {
                for (var row = 0; row < board.Rows; row++)
                {
                    for (var col = 0; col < board.Columns; col++)
                    {
                        var pieces = GetSection(board, row, col, direction.Item1, direction.Item2, 2);
                        if (pieces.All(p => p == player))
                        {
                            pairs.Add(pieces.ToList());
                        }
                    }
                }
            }

            return pairs;
        }

        private IEnumerable<(int, int)> GetPairsDirections()
        {
            var directions = new List<(int, int)>();
            directions.Add((-1, 0)); // up
            directions.Add((1, 0)); // down
            directions.Add((0, -1)); // left
            directions.Add((0, 1)); // right
            directions.Add((-1, -1)); // up-left
            directions.Add((1, 1)); // down-right
            directions.Add((-1, 1)); // up-right
            directions.Add((1, -1)); // down-left);
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