using TaskManager.Data.Projects;
using TaskManager.Storage.Projects;

namespace TaskManager.Storage.JSON
{
    class ProjectStorage : DataStorage<IProject>, IProjectStorage
    {
        public ProjectStorage(string path) : base(path) { }
    }
 }
