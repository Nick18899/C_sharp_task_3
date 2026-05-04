public static class CollectionUtils
{
    public static List<T> Distinct<T>(List<T> source)
    {
        var seen = new HashSet<T>();
        var result = new List<T>();
        foreach (var item in source)
            if (seen.Add(item))
                result.Add(item);
        return result;
    }

    public static Dictionary<TKey, List<TValue>> GroupBy<TValue, TKey>(
        List<TValue> source,
        Func<TValue, TKey> keySelector) where TKey : notnull
    {
        var result = new Dictionary<TKey, List<TValue>>();
        foreach (var item in source)
        {
            var key = keySelector(item);
            if (!result.TryGetValue(key, out var list))
            {
                list = new List<TValue>();
                result[key] = list;
            }
            list.Add(item);
        }
        return result;
    }

    public static Dictionary<TKey, TValue> Merge<TKey, TValue>(
        Dictionary<TKey, TValue> first,
        Dictionary<TKey, TValue> second,
        Func<TValue, TValue, TValue> conflictResolver) where TKey : notnull
    {
        var result = new Dictionary<TKey, TValue>(first);
        foreach (var kvp in second)
        {
            if (result.TryGetValue(kvp.Key, out var existing))
                result[kvp.Key] = conflictResolver(existing, kvp.Value);
            else
                result[kvp.Key] = kvp.Value;
        }
        return result;
    }

    public static T MaxBy<T, TKey>(List<T> source, Func<T, TKey> selector)
        where TKey : IComparable<TKey>
    {
        if (source.Count == 0)
            throw new InvalidOperationException("Collection is empty.");

        var maxItem = source[0];
        var maxKey = selector(maxItem);
        for (int i = 1; i < source.Count; i++)
        {
            var key = selector(source[i]);
            if (key.CompareTo(maxKey) > 0)
            {
                maxKey = key;
                maxItem = source[i];
            }
        }
        return maxItem;
    }
}
