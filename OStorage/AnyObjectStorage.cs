using System.Collections.Concurrent;

namespace OStorage;

public class AnyObjectStorage<TKey, TValue> : IAnyObjectStorage<TKey, TValue>
{
    private readonly ConcurrentDictionary<TKey, TValue?> _dataMap;

    protected AnyObjectStorage()
    {
        _dataMap = new ConcurrentDictionary<TKey, TValue?>();
    }

    public void AddOrUpdate(TKey key, TValue? val)
    {
        _dataMap.AddOrUpdate(key, val, (k, v) => val);
    }

    public TValue? Get(TKey key)
    {
        if (_dataMap.TryGetValue(key, out TValue? value))
        {
            return value;
        }

        return default;
    }

    public TValue? GetOrAdd(TKey key, Func<TKey, TValue> func)
    {
        return _dataMap.GetOrAdd(key, func);
    }

    public IReadOnlyList<TValue?> GetAll()
    {
        return _dataMap.Values.ToList().AsReadOnly();
    }

    public void Remove(TKey key)
    {
        _dataMap.TryRemove(key, out TValue? value);
    }

    public bool Exists(TKey key)
    {
        return _dataMap.ContainsKey(key);
    }

    public void Clear()
    {
        _dataMap.Clear();
    }
}

public class AnyObjectStorage<TValue> : AnyObjectStorage<string, TValue>, IAnyObjectStorage<TValue>
{
}