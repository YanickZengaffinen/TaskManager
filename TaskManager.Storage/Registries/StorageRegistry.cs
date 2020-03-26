using System;
using System.Collections.Generic;

namespace TaskManager.Storage.Registries
{
    class StorageRegistry : IStorageRegistry
    {
        protected Dictionary<Type, IStorage> factories = new Dictionary<Type, IStorage>();

        public IStorage this[Type key] => factories[key];

        public IStorage<T> GetStorage<T>()
        {
            return this[typeof(T)] as IStorage<T>;
        }

        public bool Register<T>(IStorage<T> value) => Register(typeof(T), value);

        public bool Register(Type key, IStorage value)
        {
            factories.Add(key, value);
            return true;
        }
    }
}
