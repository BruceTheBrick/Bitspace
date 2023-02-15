namespace Bitspace.Features
{
    public class ConnectFourDifficultyService : IConnectFourDifficultyService
    {
        public IConnectFourScoringService GetScoringServiceFromDifficulty(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Hard:
                    return new ConnectFourScoringService2();
                case Difficulty.Medium:
                    return new ConnectFourScoringService2();
                case Difficulty.Easy:
                default:
                    return new ConnectFourScoringService2();
            }
        }
    }
}