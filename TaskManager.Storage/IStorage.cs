using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Storage
{
    public interface IStorage<T> : IDisposable
    {
        IStorage<T> Connect();

        T Read();

        bool Update(T data);
    }
}
