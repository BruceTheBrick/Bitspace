namespace Bitspace.Services
{
    public interface IEssentialsVersion
    {
        public string CurrentVersion();
        public string CurrentBuildNumber();
    }
}