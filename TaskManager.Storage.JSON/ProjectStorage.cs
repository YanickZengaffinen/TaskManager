using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Data.Projects;
using TaskManager.Storage.Projects;

namespace TaskManager.Storage.JSON
{
    class ProjectStorage : IProjectStorage
    {
        private readonly Dictionary<long, IProject> projects = new Dictionary<long, IProject>();

        public IProject Create(IProject template)
        {
            long id = GetNextProjectId();
            var inst = template.CloneUsingId(id) as IProject;
            projects.Add(id, inst);
            return inst;
        }

        public IProject Create()
        {
            long id = GetNextProjectId();
            //var inst = DataRegistry...
            throw new NotImplementedException();
        }

        private long GetNextProjectId()
        {
            return projects.Count == 0 ? 0 : projects.Max(x => x.Key) + 1;
        }

        public void Delete(long id)
        {
            projects.Remove(id);
        }

        public void Delete(IProject entry)
        {
            //TODO: log warning if not actually equal
            Delete(entry.Id);
        }

        public void Dispose()
        {
            Save();
            projects.Clear();
        }

        public IEnumerable<IProject> GetAll()
        {
            return Read();
        }

        public IEnumerable<IProject> Read()
        {
            return projects.Values.ToList();
        }

        public bool TryGetById(long id, out IProject project)
        {
            return projects.TryGetValue(id, out project);
        }

        public void Update()
        {
            Save();
        }

        public void Update(IProject entry)
        {
            //Not supported in JSON
            if(projects.ContainsKey(entry.Id))
            {
                projects.Remove(entry.Id);
                projects.Add(entry.Id, entry);
                Save();
            }
        }

        public void Save()
        {
            //write to file
        }
    }
}
