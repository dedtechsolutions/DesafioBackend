using DesafioBack.Application.Interfaces;
using DesafioBack.Application.Mappings;
using DesafioBack.Application.Services;
using DesafioBack.Domain.Interfaces;
using DesafioBack.Infra.Data.Context;
using DesafioBack.Infra.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace DesafioBack.Api
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            services.AddScoped<ITaskToolRepository, TaskToolRepository>();
            services.AddScoped<ITaskToolServices, TaskToolServices>();
            services.AddAutoMapper(typeof(DomainToDTOMapping));

            services.AddMvc().AddJsonOptions(
                options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesafioBack.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesafioBack.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
