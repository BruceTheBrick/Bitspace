using System;
using Bitspace.Resources;
using PropertyChanged;

namespace Bitspace.Features
{
    [AddINotifyPropertyChangedInterface]
    public class ConnectFourEngine : IConnectFourEngine
    {
        private readonly IConnectFourScoringService _scoringService;

        public ConnectFourEngine(IConnectFourScoringService scoringService)
        {
            _scoringService = scoringService;
        }

        public string Name { get; set; } = ConnectFourRegister.CF_ENGINE_NAME;
        public int MovesChecked { get; set; }
        public Piece EnginePiece { get; set; }

        public void SetEnginePiece(Piece player)
        {
            EnginePiece = player;
            _scoringService.SetMaximisingPlayer(player);
        }

        public int GetNextMove(IBoard board)
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

                board.PlacePiece(x, EnginePiece);
                var score = Minimax(board, GetDepth(), true);
                board.Undo();

                if (score > bestScore)
                {
                    move = x;
                }

                bestScore = Math.Max(bestScore, score);
            }

            return move;
        }

        public int Minimax(IBoard board, int depth, bool isMaximising)
        {
            if (ShouldEvaluateBoard(board, depth))
            {
                return Evaluate(board, isMaximising);
            }

            if (isMaximising)
            {
                return Maxi(board, depth);
            }

            return Mini(board, depth);
        }

        private int Mini(IBoard board, int depth)
        {
            if (ShouldEvaluateBoard(board, depth))
            {
                return Evaluate(board, false);
            }

            var bestScore = int.MaxValue;
            for (var x = 0; x < board.Rows; x++)
            {
                if (board.IsColumnFull(x))
                {
                    continue;
                }

                board.PlacePiece(x, EnginePiece.GetOtherPiece());
                var score = Maxi(board, depth - 1);
                board.Undo();
                bestScore = Math.Min(score, bestScore);
            }

            return bestScore;
        }

        private int Maxi(IBoard board, int depth)
        {
            if (ShouldEvaluateBoard(board, depth))
            {
                return Evaluate(board, true);
            }

            var bestScore = int.MinValue;
            for (var x = 0; x < board.Rows; x++)
            {
                if (board.IsColumnFull(x))
                {
                    continue;
                }

                board.PlacePiece(x, EnginePiece);
                var score = Mini(board, depth - 1);
                board.Undo();
                bestScore = Math.Max(score, bestScore);
            }

            return bestScore;
        }

        private int Evaluate(IBoard board, bool isMaximising)
        {
            if (isMaximising)
            {
                return _scoringService.GetScore(board, true);
            }

            return _scoringService.GetScore(board, false);
        }

        private bool ShouldEvaluateBoard(IBoard board, int depth)
        {
            return depth == 0 || board.IsFull();
        }

        private int GetDepth()
        {
            return 0;
        }
    }
}