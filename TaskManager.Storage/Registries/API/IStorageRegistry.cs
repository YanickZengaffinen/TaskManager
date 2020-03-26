using System;
using TaskManager.Base.Registries;

namespace TaskManager.Storage.Registries
{
    public interface IStorageRegistry : IRegistry<Type, IStorage>
    {
        IStorage<T> GetStorage<T>();

        bool Register<T>(IStorage<T> value);
    }
}
