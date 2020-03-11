using System;
using System.Collections.Generic;
using TaskManager.Base.Factories;

namespace TaskManager.Data.Registries
{
    class DataRegistry : IDataRegistry
    {
        protected Dictionary<Type, IFactory<IData>> factories = new Dictionary<Type, IFactory<IData>>();

        public IFactory<IData> this[Type key] => factories[key];

        public T CreateNew<T>()
        {
            return (T)this[typeof(T)].Produce();
        }

        public IFactory<T> GetFactory<T>()
        {
            return (IFactory<T>)this[typeof(T)];
        }

        public bool Register(Type key, IFactory<IData> value)
        {
            factories.Add(key, value);
            return true;
        }
    }
}
