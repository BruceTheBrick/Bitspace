namespace Bitspace.Core;

public static class ArrayExtensions
{
    public static T[,] Init2DArray<T>(int rows, int columns, T defaultValue)
    {
        var array = new T[rows, columns];
        for (var x = 0; x < rows; x++)
        {
            for (var y = 0; y < columns; y++)
            {
                array[x, y] = defaultValue;
            }
        }

        return array;
    }
}