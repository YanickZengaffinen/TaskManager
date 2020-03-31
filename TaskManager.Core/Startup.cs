using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using TaskManager.Base;
using TaskManager.Data.Projects;
using TaskManager.Storage.JSON;
using TaskManager.Storage.Projects;

namespace TaskManager.Core
{
    public class Startup
    {
        private const String FilePath = "E:/storage";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //setup registries
             var dataRegistry = Data.DataModule.CreateDefaultDataRegistry();

            var storageRegistry = JsonStorageModule.CreateDefaultJsonStorageRegistry(FilePath);


            //register all custom implementations

            //register all registries to master
            MasterRegistry.Instance.Register(storageRegistry);
            MasterRegistry.Instance.Register(dataRegistry);

            //temp: populate storages
            var projectStorage = storageRegistry.GetStorage<IProject>() as IProjectStorage;

            for (int i = 0; i < 10; i++)
            {
                var projectTemplate = dataRegistry.CreateNew<IProject>();
                projectTemplate.Name = "Hello" + i;
                projectTemplate.Description = "World" + i;

                projectStorage.Create(projectTemplate);
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManager API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManager API v1");
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
