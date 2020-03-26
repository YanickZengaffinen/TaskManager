using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data.Projects;
using TaskManager.Storage.Projects;

namespace TaskManager.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[AutoValidateAntiforgeryToken]
    //[Authorize]
    public class ProjectsController : ControllerBase
    {
        private IProjectStorage Storage => Startup.Instance.StorageRegistry.GetStorage<IProject>() as IProjectStorage;

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
            var template = Startup.Instance.DataRegistry.CreateNew<IProject>();

            template.Name = name;
            template.Description = description;

            return Storage.Create(template);
        }

        //Read
        [HttpGet]
        [Route("get")]
        public async Task<IEnumerable<IProject>> Get()
        {
            return Storage.Read();
        }

        [HttpGet]
        [Route("{id:long}/get")]
        public async Task<IProject> Get([FromRoute] long id)
        {
            if (Storage.TryGetById(id, out IProject project))
            {
                return project;
            }

            return null;
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