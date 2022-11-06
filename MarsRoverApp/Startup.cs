using MarsRover.Domain.Commands;
using MarsRover.Domain.Concrete;
using MarsRover.Domain.Interface;
using MarsRover.Domain.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace MarsRoverApp
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
            services.AddSingleton<IPositionInputValidator, PositionInputValidator>();
            services.AddTransient<ICommandCenter, CommandCenter>();
            services.AddTransient<IRover, Rover>(sp =>
            {
                var factory = sp.GetRequiredService<IPosition>();
                return new Rover(factory);
            });
            services.AddTransient<ISurface>(x =>new Surface(5,5)) ;
            services.AddTransient<IPosition>(x => new Position(1, 1, MarsRover.Domain.Enum.DirectionEnum.N));
            services.AddControllers();
            services.AddMvc()
            .AddNewtonsoftJson(opts =>
             {
                 opts.SerializerSettings.Converters.Add(new StringEnumConverter());
             });
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MarsRoverApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarsRoverApp v1"));
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
