using System;
using Bitspace.Resources;

namespace Bitspace.Features
{
    public class ConnectFourEngine : IConnectFourEngine
    {
        private readonly IConnectFourScoringService _scoringService;
        private Piece _player;

        public ConnectFourEngine(IConnectFourScoringService scoringService)
        {
            _scoringService = scoringService;
        }

        public string Name { get; set; } = ConnectFourRegister.CF_ENGINE_NAME;

        public void SetPlayer(Piece player)
        {
            _player = player;
            _scoringService.SetMaximisingPlayer(player);
        }

        public int GetNextMove(IBoard board, Piece player)
        {
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
            if (depth == 0 || board.IsFull())
            {
                return Evaluate(board, isMaximising);
            }

            int bestScore;
            if (isMaximising)
            {
                bestScore = int.MinValue;
                for (var x = 0; x < board.Rows; x++)
                {
                    if (board.IsColumnFull(x))
                    {
                        continue;
                    }

                    board.PlacePiece(x, _player);
                    var score = Minimax(board, depth - 1, false);
                    board.Undo();
                    bestScore = Math.Max(score, bestScore);
                }

                return bestScore;
            }

            bestScore = int.MaxValue;
            for (var x = 0; x < board.Rows; x++)
            {
                if (board.IsColumnFull(x))
                {
                    continue;
                }

                board.PlacePiece(x, _player.GetOtherPiece());
                var score = Minimax(board, depth - 1, true);
                board.Undo();
                bestScore = Math.Min(score, bestScore);
            }

            return bestScore;
        }

        public int Evaluate(IBoard board, bool isMaximising)
        {
            var currentPlayerScore = _scoringService.GetScore(board, true);
            var minimisingPlayerScore = _scoringService.GetScore(board, false);
            return currentPlayerScore - minimisingPlayerScore;
        }

        private int GetDepth()
        {
            return 5;
        }
    }
}