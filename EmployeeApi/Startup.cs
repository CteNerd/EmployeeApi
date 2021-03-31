using System;
using System.Reflection;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace EmployeeApi
{
    public class Startup
    {
        private readonly AppSettings _appSettings;
        private readonly IWebHostEnvironment _environment;
        public IConfiguration _configuration { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
            _appSettings = _configuration.Get<AppSettings>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_environment.IsDevelopment() || _environment.IsStaging())
            {
                _configuration.GetSection($"profiles:{_environment.EnvironmentName}:environmentVariables").Bind(_appSettings);
            }
            else
            {
                _configuration.GetSection($"profiles:{_environment.EnvironmentName}:environmentVariables").Bind(_appSettings);
            }

            Assembly assembly = Assembly.GetExecutingAssembly();

            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.UseCamelCasing(true);
            });

            services.AddSingleton(_appSettings);
            services.AddSingleton(_configuration);

            EmployeeRepository.Registrar.Register(services);
            EmployeeBusinessLogic.Registrar.Register(services);

            services.Configure<AppSettings>(_configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Employee API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://employee.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Roderick Tomlin",
                        Email = "rtomlin62@gmail.com",
                        Url = new Uri("https://www.mockApi.com"),
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
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeApi v1"));
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
