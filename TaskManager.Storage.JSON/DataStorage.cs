using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Base;
using TaskManager.Data;
using TaskManager.Data.Registries;
using TaskManager.Storage.Storage;

namespace TaskManager.Storage.JSON
{
    class DataStorage<T> : IDataStorage<T> where T : IData
    {
        protected string Path { get; }

        protected Dictionary<long, T> datas = new Dictionary<long, T>();

        protected DataStorage(string path)
        {
            Path = path;

            //initially load the storage
            Load();
        }

        public T Create(T template)
        {
            long id = GetNextDataId();
            var inst = (T)template.CloneUsingId(id);
            datas.Add(id, inst);

            Save();
            return inst;
        }

        public T Create()
        {
            long id = GetNextDataId();
            var inst = MasterRegistry.Get<IDataRegistry>().CreateNew<T>();

            Save();
            return inst;
        }

        private long GetNextDataId()
        {
            return datas.Count == 0 ? 0 : datas.Max(x => x.Key) + 1;
        }

        public void Delete(long id)
        {
            datas.Remove(id);
            Save();
        }

        public void Delete(T entry)
        {
            //TODO: log warning if not actually equal
            Delete(entry.Id);
            Save();
        }

        public void Dispose()
        {
            Save();
            datas.Clear();
        }

        public IEnumerable<T> Read()
        {
            return datas.Values.ToList();
        }

        public bool TryGetById(long id, out T project)
        {
            return datas.TryGetValue(id, out project);
        }

        public void Update(T entry)
        {
            //Not supported in JSON
            if (datas.ContainsKey(entry.Id))
            {
                datas.Remove(entry.Id);
                datas.Add(entry.Id, entry);
                Save();
            }
        }

        public void Save()
        {
            JsonUtil.SaveToFile<IEnumerable<T>>(Path, datas.Values);
        }

        public void Load()
        {
            var dataValues = JsonUtil.ReadFromFile<IEnumerable<T>>(Path + "/datas.json");
            if(dataValues != null && dataValues.Count() > 0)
            {
                datas = dataValues.ToDictionary(x => x.Id);
            }
        }
    }
}
