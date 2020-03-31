using System.Collections.Generic;
using System.Linq;
using TaskManager.Data.Todos;
using TaskManager.Storage.Todos;

namespace TaskManager.Storage.JSON
{
    class TodoStorage : DataStorage<ITodo>, ITodoStorage
    {
        public TodoStorage(string path) : base(path) { }

        public IEnumerable<ITodo> GetTodosForProject(long projectId)
        {
            return datas.Values.Where(x => x.ProjectId == projectId).ToList();
        }

        public override void Load()
        {
            //TODO: give json deserializer type info for ITodo interface
            var dataValues = JsonUtil.ReadFromFile<List<Todo>>(Path);
            if (dataValues != null && dataValues.Count() > 0)
            {
                datas = dataValues.Cast<ITodo>().ToDictionary(x => x.Id);
            }
        }
    }
}
