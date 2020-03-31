using System;
using TaskManager.Base.Registries;

namespace TaskManager.Storage.Registries
{
    public interface IStorageRegistry : IRegistry<Type, IStorage>
    {
        /// <summary>
        /// Get the storage responsible for storing the specified type
        /// </summary>
        IStorage<T> GetStorage<T>();

        /// <summary>
        /// Register a storage responsible for storing the specified type
        /// </summary>
        bool Register<T>(IStorage<T> value);
    }
}
