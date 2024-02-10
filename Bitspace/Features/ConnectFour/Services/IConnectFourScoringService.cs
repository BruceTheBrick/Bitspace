namespace Bitspace.Features;

public interface IConnectFourScoringService
{
    public void SetMaximisingPlayer(Piece player);
    public int GetScore(IBoard board);
}