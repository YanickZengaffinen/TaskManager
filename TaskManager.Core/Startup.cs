using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TaskManager.Base;
using TaskManager.Storage.JSON;

namespace TaskManager.Core
{
    public class Startup
    {
        private const string FilePath = "E:/storage";
        private readonly string CorsPolicyName = "_cors";

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
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyName,
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyHeader();
                        builder.AllowCredentials();
                        builder.AllowAnyMethod();
                    });
            });

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

            app.UseCors(CorsPolicyName);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
