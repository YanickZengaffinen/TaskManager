using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Base.Registries
{
    public interface IRegistry<K, V>
    {
        V this[K key] { get; }

        bool Register(K key, V value);
    }
}
