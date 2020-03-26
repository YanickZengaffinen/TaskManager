using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Base.Factories;
using TaskManager.Data;
using TaskManager.Data.Projects;
using TaskManager.Storage.Projects;
using TaskManager.Storage.Registries;

namespace TaskManager.Storage.JSON
{
    public static class JsonStorageModule
    {
        public static IStorageRegistry CreateDefaultJsonStorageRegistry()
        {
            var storageRegistry = StorageModule.CreateDefaultStorageRegistry();

            //Projects
            var projectStorage = new ProjectStorage();
            storageRegistry.Register(typeof(IProject), projectStorage);


            return storageRegistry;
        }

    }
}
