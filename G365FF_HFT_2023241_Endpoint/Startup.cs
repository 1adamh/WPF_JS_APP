using G365FF_HFT_2023241.Logic.Class;
using G365FF_HFT_2023241.Logic.Interface;
using G365FF_HFT_2023241.Models;
using G365FF_HFT_2023241.Repository.Class;
using G365FF_HFT_2023241.Repository.Data;
using G365FF_HFT_2023241.Repository.Interface;
using G365FF_HFT_2023241_Endpoint.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace G365FF_HFT_2023241_Endpoint
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
            services.AddSingleton<TaxiDbContext>();

            services.AddTransient<IRepository<Ride>, RideRepo>();
            services.AddTransient<IRepository<Taxi>, TaxiRepo>();
            services.AddTransient<IRepository<Passenger>, PassengerRepo>();


            services.AddTransient<IRideLogic,RideLogic>();
            services.AddTransient<ITaxiLogic, TaxiLogic>();
            services.AddTransient<IPassengerLogic, PassengerLogic>();

            services.AddSignalR();
                
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "G365FF_HFT_2023241_Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "G365FF_HFT_2023241_Endpoint v1"));
            }
            //http://localhost:55196
            app.UseCors(x => x
               .AllowCredentials()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithOrigins("http://localhost:55196"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
