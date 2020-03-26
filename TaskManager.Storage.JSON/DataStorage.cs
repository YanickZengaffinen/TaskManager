using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Data;
using TaskManager.Storage.Storage;

namespace TaskManager.Storage.JSON
{
    class DataStorage<T> : IDataStorage<T> where T : IData
    {
        protected readonly Dictionary<long, T> datas = new Dictionary<long, T>();

        public T Create(T template)
        {
            long id = GetNextDataId();
            var inst = (T)template.CloneUsingId(id);
            datas.Add(id, inst);
            return inst;
        }

        public T Create()
        {
            long id = GetNextDataId();
            //var inst = DataRegistry...
            throw new NotImplementedException();
        }

        private long GetNextDataId()
        {
            return datas.Count == 0 ? 0 : datas.Max(x => x.Key) + 1;
        }

        public void Delete(long id)
        {
            datas.Remove(id);
        }

        public void Delete(T entry)
        {
            //TODO: log warning if not actually equal
            Delete(entry.Id);
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
            //write to file
        }
    }
}
