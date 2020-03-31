using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Base;
using TaskManager.Data.Projects;
using TaskManager.Data.Registries;
using TaskManager.Data.Todos;
using TaskManager.Storage.Projects;
using TaskManager.Storage.Registries;
using TaskManager.Storage.Todos;

namespace TaskManager.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AutoValidateAntiforgeryToken]
    //[Authorize]
    public class ProjectsController : ControllerBase
    {
        protected IProjectStorage Storage => MasterRegistry.Get<IStorageRegistry>()
            .GetStorage<IProject>() as IProjectStorage;

        protected ITodoStorage TodoStorage => MasterRegistry.Get<IStorageRegistry>()
            .GetStorage<ITodo>() as ITodoStorage;

        //Create
        [HttpPost]
        [Route("create")]
        public async Task<IProject> Create([FromBody] Project template)
        {
            return Storage.Create(template);
        }

        [HttpGet]
        [Route("create")]
        public async Task<IProject> Create(string name, string description)
        {
            var template = MasterRegistry.Get<IDataRegistry>().CreateNew<IProject>();

            template.Name = name;
            template.Description = description;

            return Storage.Create(template);
        }

        //Read
        [HttpGet]
        public async Task<IEnumerable<IProject>> Get()
        {
            return Storage.Read();
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IProject> Get([FromRoute] long id)
        {
            if (Storage.TryGetById(id, out IProject project))
            {
                return project;
            }

            return null;
        }

        [HttpGet]
        [Route("{id:long}/todos")]
        public async Task<IEnumerable<ITodo>> GetTodos([FromRoute] long id)
        {
            return TodoStorage.GetTodosForProject(id);
        }

        //Update
        [HttpPost]
        [Route("{id:long}/update")]
        public async Task Update([FromRoute] long id, [FromBody] Project template)
        {
            Storage.Update(template.CloneUsingId(id) as IProject);
        }


        //Delete
        [HttpGet]
        [Route("{id:long}/delete")]
        public async Task Delete([FromRoute] long id)
        {
            Storage.Delete(id);
        }
    }
}