namespace Bitspace.Features
{
    public interface IConnectFourScoringService
    {
        public int GetScore(IBoard board, bool isMaximisingPlayer);
    }
}