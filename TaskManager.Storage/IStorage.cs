using System;
using System.Collections.Generic;

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
        /// <summary>
        /// Create a default entry of the stored data type in the storage
        /// </summary>
        T Create();

        /// <summary>
        /// Read all entries stored in this storage
        /// </summary>
        IEnumerable<T> Read();

        /// <summary>
        /// Updates an entry which must already exist in the storage
        /// </summary>
        void Update(T entry);

        /// <summary>
        /// Deletes an entry from the storage
        /// </summary>
        void Delete(T entry);
    }
}
