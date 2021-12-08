using System;
using System.Collections.Generic;

namespace Application.Commons.Extensions
{
    public static class CollectionForEachExtension
    {
        public static void ForEach<T>(this ICollection<T> collection, Action<T> action)
        {
            foreach (var task in collection)
            {
                action.Invoke(task);
            }
        }
    }
}
