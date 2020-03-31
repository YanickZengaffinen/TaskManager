using System;
using System.Collections.Generic;
using TaskManager.Base.Registries;

namespace TaskManager.Base
{
    public class MasterRegistry : IRegistry<Type, object>
    {
        private static readonly Lazy<MasterRegistry> instance = new Lazy<MasterRegistry>(() => new MasterRegistry());
        public static MasterRegistry Instance => instance.Value;

        private readonly Dictionary<Type, object> entries = new Dictionary<Type, object>();

        public object this[Type key] => entries[key];

        public bool Register(Type key, object value)
        {
            entries.Add(key, value);
            return true;
        }

        public bool Register<T>(T value)
        {
            return Register(typeof(T), value);
        }

        //static wrappers
        public static T Get<T>()
        {
            return (T)Instance[typeof(T)];
        }

    }
}
