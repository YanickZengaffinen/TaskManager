using System.Collections.Generic;
using System.Linq;
using TaskManager.Data.Todos;
using TaskManager.Storage.Todos;

namespace TaskManager.Storage.JSON
{
    class TodoStorage : DataStorage<ITodo>, ITodoStorage
    {
        public IEnumerable<ITodo> GetTodosForProject(long projectId)
        {
            return datas.Values.Where(x => x.ProjectId == projectId).ToList();
        }
    }
}
