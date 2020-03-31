using TaskManager.Storage.Registries;

namespace TaskManager.Storage.JSON
{
    public static class JsonStorageModule
    {
        private const string ProjectsPath = "projects";
        private const string TodosPath = "todos";

        public static IStorageRegistry CreateDefaultJsonStorageRegistry(string path)
        {
            var storageRegistry = StorageModule.CreateDefaultStorageRegistry();

            //Projects
            var projectStorage = new ProjectStorage(path + "/" + ProjectsPath + "/data.json");
            projectStorage.Load();
            storageRegistry.Register(projectStorage);

            //Todos
            var todoStorage = new TodoStorage(path + "/" + TodosPath + "/data.json");
            todoStorage.Load();
            storageRegistry.Register(todoStorage);

            return storageRegistry;
        }

    }
}
