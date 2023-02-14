using System;
using Bitspace.Resources;
using PropertyChanged;

namespace Bitspace.Features
{
    [AddINotifyPropertyChangedInterface]
    public class ConnectFourEngine : IConnectFourEngine
    {
        private readonly IConnectFourScoringService _scoringService;
        private Piece _maximisingPlayer;

        public ConnectFourEngine(IConnectFourScoringService scoringService)
        {
            _scoringService = scoringService;
        }

        public string Name { get; set; } = ConnectFourRegister.CF_ENGINE_NAME;
        public int MovesChecked { get; set; }

        public void SetPlayer(Piece player)
        {
            _maximisingPlayer = player;
            _scoringService.SetMaximisingPlayer(player);
        }

        public int GetNextMove(IBoard board, Piece player)
        {
            MovesChecked = 0;
            var bestScore = int.MinValue;
            var move = -1;
            for (var x = 0; x < board.Columns; x++)
            {
                if (board.IsColumnFull(x))
                {
                    continue;
                }

                board.PlacePiece(x, player);
                var score = Minimax(board, GetDepth(), true);
                board.Undo();
                if (score <= bestScore)
                {
                    continue;
                }

                bestScore = score;
                move = x;
            }

            return move;
        }

        public int Minimax(IBoard board, int depth, bool isMaximising)
        {
            MovesChecked++;
            if (depth == 0 || board.IsFull())
            {
                return Evaluate(board, isMaximising);
            }

            var bestScore = GetInitialScore(isMaximising);
            var piece = GetPlayerPiece(isMaximising);
            for (var x = 0; x < board.Rows; x++)
            {
                if (board.IsColumnFull(x))
                {
                    continue;
                }

                board.PlacePiece(x, piece);
                var score = Minimax(board, depth - 1, !isMaximising);
                board.Undo();
                bestScore = isMaximising
                    ? Math.Max(score, bestScore)
                    : Math.Min(score, bestScore);
            }

            return bestScore;
        }

        public int Evaluate(IBoard board, bool isMaximising)
        {
            var score = _scoringService.GetScore(board, isMaximising);
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
            return 0;
        }
    }
}