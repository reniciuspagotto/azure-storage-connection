using AzureStorage.Core.Contracts;
using AzureStorage.Core.Handles;
using AzureStorage.Infra.Context;
using AzureStorage.Infra.Contracts;
using AzureStorage.Infra.Options;
using AzureStorage.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AzureStorage.Api
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
            services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddOptions();
            services.Configure<StorageConfiguration>(Configuration.GetSection("StorageConfiguration"));

            services.AddTransient<ProductHandle, ProductHandle>();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "AzureStorageDemo"));
            services.AddScoped<DataContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
