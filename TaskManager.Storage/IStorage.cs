using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Storage
{
    /// <summary>
    /// Tagging interface
    /// </summary>
    public interface IStorage { }

    /// <summary>
    /// Storage access interface
    /// </summary>
    /// <typeparam name="T">The type of an entry</typeparam>
    public interface IStorage<T> : IStorage, IDisposable
    {
        T Create();

        IEnumerable<T> Read();

        void Update(T entry);

        void Delete(T entry);
    }
}
