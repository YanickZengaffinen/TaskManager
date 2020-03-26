using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Storage.Registries;

namespace TaskManager.Storage
{
    public static class StorageModule
    {
        public static IStorageRegistry CreateDefaultStorageRegistry()
        {
            return new StorageRegistry();
        }

    }
}
