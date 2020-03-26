using System.Collections.Generic;
using TaskManager.Base;
using TaskManager.Data.Projects;
using TaskManager.Data.Todos;
using TaskManager.Storage.Projects;
using TaskManager.Storage.Todos;

namespace TaskManager.Storage.JSON
{
    class ProjectStorage : DataStorage<IProject>, IProjectStorage
    {
    }
}
