using TaskManager.Data;

namespace TaskManager.Storage.Storage
{
    public interface IDataStorage<T> : IStorage<T> where T : IData
    {
        /// <summary>
        /// Creates a new entry on this storage and returns the empty entry
        /// </summary>
        T Create(T template);

        /// <summary>
        /// Tries to get an entry by its id
        /// </summary>
        bool TryGetById(long id, out T data);

        /// <summary>
        /// Deletes an entry by its id
        /// </summary>
        void Delete(long id);
    }
}
