using System;
using System.Diagnostics;
using Bitspace.Resources;
using PropertyChanged;

namespace Bitspace.Features
{
    [AddINotifyPropertyChangedInterface]
    public class ConnectFourEngine : IConnectFourEngine
    {
        private readonly IConnectFourScoringService _scoringService;
        private readonly Piece _maximisingPlayer;

        public ConnectFourEngine(string name, Piece player, IConnectFourScoringService scoringService)
        {
            Name = name;
            _maximisingPlayer = player;

            _scoringService = scoringService;
            _scoringService.SetMaximisingPlayer(_maximisingPlayer);
        }

        public string Name { get; }

        public int GetNextMove(IBoard board)
        {
            var bestScore = int.MinValue;
            var column = -1;
            for (var currentColumn = 0; currentColumn < board.Columns; currentColumn++)
            {
                if (board.IsColumnFull(currentColumn))
                {
                    continue;
                }

                board.PlacePiece(currentColumn, _maximisingPlayer);
                var score = Minimax(board, GetDepth(), false);
                board.Undo();
                if (score <= bestScore)
                {
                    continue;
                }

                bestScore = score;
                column = currentColumn;
            }

            Debug.WriteLine($"Best Score: {bestScore}, Column: {column} ---------------------------------");
            return column;
        }


        private int Minimax(IBoard board, int depth, bool isMaximising)
        {
            if (depth == 0 || board.IsFull())
            {
                return Evaluate(board);
            }

            var bestScore = GetInitialScore(isMaximising);
            var piece = GetPlayerPiece(isMaximising);
            for (var currentColumn = 0; currentColumn < board.Columns; currentColumn++)
            {
                if (board.IsColumnFull(currentColumn))
                {
                    continue;
                }

                board.PlacePiece(currentColumn, piece);
                var score = Minimax(board, depth - 1, !isMaximising);
                board.Undo();
                bestScore = isMaximising
                    ? Math.Max(score, bestScore)
                    : Math.Min(score, bestScore);
            }

            return bestScore;
        }

        private int Evaluate(IBoard board)
        {
            var score = _scoringService.GetScore(board);
            Debug.Write($"{board.ToString()} \n");
            Debug.Write($"Score: {score}\n");
            return score;
        }

        private Piece GetPlayerPiece(bool isMaximising)
        {
            return isMaximising
                ? _maximisingPlayer
                : _maximisingPlayer.GetOpponent();
        }

        private int GetInitialScore(bool isMaximising)
        {
            return isMaximising
                ? int.MinValue
                : int.MaxValue;
        }

        private int GetDepth()
        {
            return 2;
        }
    }
}