namespace Bitspace.Features
{
    public interface IConnectFourDifficultyService
    {
        public IConnectFourScoringService GetScoringServiceFromDifficulty(Difficulty difficulty);
    }
}