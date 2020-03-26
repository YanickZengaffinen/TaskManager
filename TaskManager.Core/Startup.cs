using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using TaskManager.Data.Projects;
using TaskManager.Data.Registries;
using TaskManager.Storage.JSON;
using TaskManager.Storage.Projects;
using TaskManager.Storage.Registries;

namespace TaskManager.Core
{
    public class Startup
    {
        public static Startup Instance { get; private set; }

        public IDataRegistry DataRegistry { get; } //not clear if even used yet

        public IStorageRegistry StorageRegistry { get; }

        public Startup(IConfiguration configuration)
        {
            Instance = this;
            Configuration = configuration;

            DataRegistry = Data.DataModule.CreateDefaultDataRegistry();
            StorageRegistry = JsonStorageModule.CreateDefaultJsonStorageRegistry();
            var projectStorage = StorageRegistry.GetStorage<IProject>() as IProjectStorage;

            for(int i = 0; i < 10; i++)
            {
                var projectTemplate = DataRegistry.CreateNew<IProject>();
                projectTemplate.Name = "Hello" + i;
                projectTemplate.Description = "World" + i;

                projectStorage.Create(projectTemplate);
            }

            //register all custom implementations
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
