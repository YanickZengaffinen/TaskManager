using System.Collections;
using System.Collections.Generic;
using TaskManager.Data.Todos;
using TaskManager.Storage.Storage;

namespace TaskManager.Storage.Todos
{
    public interface ITodoStorage : IDataStorage<ITodo>
    {
        /// <summary>
        /// Gets all todos of a project
        /// </summary>
        IEnumerable<ITodo> GetTodosForProject(long projectId);
    }
}
