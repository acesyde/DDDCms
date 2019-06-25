using DDDCms.Domain;
using DDDCms.Domain.Schemas.Entities;
using DDDCms.Domain.Schemas.Services;
using EventFlow.AspNetCore.Extensions;
using EventFlow.DependencyInjection.Extensions;
using EventFlow.Extensions;
using JsonSubTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDDCms
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHttpContextAccessor();

            services.AddEventFlow(options =>
            {
                options.AddDefaults(DomainAssemblyHelper.Assembly);
                options.RegisterServices(p => p.Register<ISchemaService, SchemaService>());
                options.ConfigureJson(p => p.AddSingleValueObjects().Configure(s => s.Converters.Add(JsonSubtypesConverterBuilder
                    .Of(typeof(FieldEntity), "kind")
                    .RegisterSubtype(typeof(StringFieldEntity), "string")
                    .SerializeDiscriminatorProperty()
                    .Build())));
                options.AddAspNetCore(p => p.RunBootstrapperOnHostStartup().UseMvcJsonOptions());
                options.UseConsoleLog();
                options.UseInMemorySnapshotStore();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}