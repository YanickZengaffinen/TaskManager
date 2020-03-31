using System.Collections.Generic;
using System.Linq;
using TaskManager.Data.Projects;
using TaskManager.Storage.Projects;

namespace TaskManager.Storage.JSON
{
    class ProjectStorage : DataStorage<IProject>, IProjectStorage
    {
        public ProjectStorage(string path) : base(path) { }

        public override void Load()
        {
            //TODO: give json deserializer type info for IProject interface
            var dataValues = JsonUtil.ReadFromFile<List<Project>>(Path);
            if (dataValues != null && dataValues.Count() > 0)
            {
                datas = dataValues.Cast<IProject>().ToDictionary(x => x.Id);
            }
        }
    }
 }
