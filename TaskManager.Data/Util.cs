using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Base.Factories;
using TaskManager.Data.Projects;
using TaskManager.Data.Registries;
using TaskManager.Data.Todos;

namespace TaskManager.Data
{
    public static class Util
    {
        /// <summary>
        /// Registers all default data types... can be overriden later
        /// </summary>
        public static IDataRegistry CreateDefaultDataRegistry()
        {
            var dataRegistry = new DataRegistry();

            //TODO: figure out how to pass next ids
            dataRegistry.Register(typeof(IProject), new Factory<IData>(() => new Project(0)));
            dataRegistry.Register(typeof(ITodo), new Factory<IData>(() => new Todo(0)));

            return dataRegistry;
        }
    }
}
