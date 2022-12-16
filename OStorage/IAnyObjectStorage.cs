using System;
using System.Collections.Generic;

namespace OStorage;

public interface IAnyObjectStorage<TKey, TValue>
{
    void AddOrUpdate(TKey key, TValue? val);

    TValue? Get(TKey key);

    TValue? GetOrAdd(TKey key, Func<TKey, TValue> func);

    IReadOnlyList<TValue?> GetAll();

    void Remove(TKey key);

    bool Exists(TKey key);

    void Clear();
}

public interface IAnyObjectStorage<TValue> : IAnyObjectStorage<string, TValue>
{
}