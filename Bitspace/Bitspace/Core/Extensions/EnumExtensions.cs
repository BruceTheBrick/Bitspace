using System;
using System.Collections.Generic;

namespace Bitspace.Core
{
    public class EnumExtensions
    {
        public static IList<T> GetList<T>() where T : Enum
        {
            var traitsList = new List<T>();
            var traits = Enum.GetValues(typeof(T));
            foreach (var trait in traits)
            {
                traitsList.Add((T)trait);
            }

            return traitsList;
        }
    }
}