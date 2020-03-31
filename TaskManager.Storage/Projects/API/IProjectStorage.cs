using System.Collections.Generic;
using TaskManager.Data.Projects;
using TaskManager.Data.Todos;
using TaskManager.Storage.Storage;

namespace TaskManager.Storage.Projects
{
    public interface IProjectStorage : IDataStorage<IProject>
    {
    }
}
