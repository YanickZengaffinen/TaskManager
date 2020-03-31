using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Base;
using TaskManager.Data.Registries;
using TaskManager.Data.Todos;
using TaskManager.Storage.Registries;
using TaskManager.Storage.Todos;

namespace TaskManager.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AutoValidateAntiforgeryToken]
    //[Authorize]
    public class TodosController : ControllerBase
    {
        private ITodoStorage Storage => MasterRegistry.Get<IStorageRegistry>()
            .GetStorage<ITodo>() as ITodoStorage;

        private IDataRegistry DataRegistry => MasterRegistry.Get<IDataRegistry>();

        //Create
        [HttpPost]
        [Route("create")]
        public async Task<ITodo> Create([FromBody] Todo template)
        {
            return Storage.Create(template);
        }

        [HttpGet]
        [Route("create")]
        public async Task<ITodo> Create(string title, string description)
        {
            var template = DataRegistry.CreateNew<ITodo>();

            template.Title = title;
            template.Description = description;

            return Storage.Create(template);
        }

        //Read
        [HttpGet]
        public async Task<IEnumerable<ITodo>> Get()
        {
            return Storage.Read();
        }

        [HttpGet]
        [Route("{id:long}/get")]
        public async Task<ITodo> Get([FromRoute] long id)
        {
            if (Storage.TryGetById(id, out ITodo project))
            {
                return project;
            }

            return null;
        }

        //Update
        [HttpPost]
        [Route("{id:long}/update")]
        public async Task Update([FromRoute] long id, [FromBody] Todo template)
        {
            Storage.Update(template.CloneUsingId(id) as ITodo);
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