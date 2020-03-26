using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Data.Projects;

namespace TaskManager.Storage.Projects
{
    public interface IProjectStorage : IStorage<IProject>
    {
        IEnumerable<IProject> GetAll();

        IProject Create(IProject template);

        bool TryGetById(long id, out IProject project);

        void Update();

        void Delete(long id);
    }
}
