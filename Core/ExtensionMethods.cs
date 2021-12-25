using System.Collections.Generic;
using System.Linq;

namespace Core
{
    /// <summary>
    /// Extension Methods class.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Verify if the item is in the list.
        /// </summary>
        /// <typeparam name="T">T.</typeparam>
        /// <param name="list">The List.</param>
        /// <param name="item">The Item.</param>
        /// <returns></returns>
        public static bool IsInList<T>(this IEnumerable<T> list, T item) where T : class
        {
            return list.Any(x => x.Equals(item));
        }
    }
}
