using System.Diagnostics;
using PropertyChanged;

namespace Bitspace.Features;

[AddINotifyPropertyChangedInterface]
public class ConnectFourEngine : IConnectFourEngine
{
    private readonly IConnectFourScoringService _scoringService;
    private readonly Piece _maximisingPlayer;

    public ConnectFourEngine(Piece player, IConnectFourScoringService scoringService)
    {
        Name = ConnectFourRegister.EngineName;
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
            var score = Minimax(board, GetDepth() - 1, _maximisingPlayer.GetOpponent());
            board.Undo();
            if (score <= bestScore)
            {
                continue;
            }

            bestScore = score;
            Debug.WriteLine($"Best score: {bestScore}");
            column = currentColumn;
        }

        Debug.WriteLine($"Best Score: {bestScore}, Column: {column} ---------------------------------");
        return column;
    }


    private int Minimax(IBoard board, int depth, Piece player)
    {
        if (depth == 0 || board.IsFull())
        {
            return Evaluate(board);
        }

        var bestScore = GetInitialScore(player);
        for (var currentColumn = 0; currentColumn < board.Columns; currentColumn++)
        {
            if (board.IsColumnFull(currentColumn))
            {
                continue;
            }

            board.PlacePiece(currentColumn, player);
            var score = Minimax(board, depth - 1, player.GetOpponent());
            board.Undo();
            bestScore = IsMaximisingPlayer(player)
                ? Math.Max(score, bestScore)
                : Math.Min(score, bestScore);
        }

        return bestScore;
    }

    private int Evaluate(IBoard board)
    {
        return _scoringService.GetScore(board);
    }

    private int GetInitialScore(Piece player)
    {
        return player == _maximisingPlayer
            ? int.MinValue
            : int.MaxValue;
    }

    private bool IsMaximisingPlayer(Piece player)
    {
        return player == _maximisingPlayer;
    }

    private int GetDepth()
    {
        return 5;
    }
}