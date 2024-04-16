namespace Bitspace.Core;

public static class EnumExtensions
{
    public static IList<T> GetList<T>() where T : Enum
    {
        var traits = Enum.GetValues(typeof(T));
        return traits.Cast<T>().ToList();
    }
}