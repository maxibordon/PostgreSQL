using ApiPostgreSQL;
using ApiPostgreSQL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgreSQL
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
            services.AddControllers();
            AddSwagger(services);
            string connectionString = Configuration.GetConnectionString("PostgreSQLConnection");         
              var postgreSQLConnectionConfiguration = new PostgreSQLConfiguration(connectionString);
            services.AddSingleton(postgreSQLConnectionConfiguration);
            services.AddScoped<IBookRepository, BookRepository>();

        }


        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";
                options.EnableAnnotations();
                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"PostgreSQL {groupName}",
                    Version = groupName,
                    Description = "POSTGRESQL API",
                    Contact = new OpenApiContact
                    {
                        Name = "PostgreSQL API",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Enel API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
