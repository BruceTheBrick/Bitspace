namespace Bitspace.Features
{
    public interface IConnectFourEngine
    {
        public string Name { get; }
        public int GetNextMove(IBoard board);
    }
}