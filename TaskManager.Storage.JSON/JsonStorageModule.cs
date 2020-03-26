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
            storageRegistry.Register(projectStorage);

            //Todos
            var todoStorage = new TodoStorage();
            storageRegistry.Register(todoStorage);

            return storageRegistry;
        }

    }
}
