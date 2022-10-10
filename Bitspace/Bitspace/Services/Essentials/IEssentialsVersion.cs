namespace Bitspace.Services.Essentials
{
    public interface IEssentialsVersion
    {
        public string CurrentVersion();
        public string CurrentBuildNumber();
    }
}