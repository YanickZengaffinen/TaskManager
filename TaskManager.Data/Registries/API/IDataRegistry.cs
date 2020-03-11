using System;
using TaskManager.Base.Factories;
using TaskManager.Base.Registries;

namespace TaskManager.Data.Registries
{
    public interface IDataRegistry : IRegistry<Type,IFactory<IData>>
    {
        IFactory<T> GetFactory<T>();
        T CreateNew<T>();
    }
}
