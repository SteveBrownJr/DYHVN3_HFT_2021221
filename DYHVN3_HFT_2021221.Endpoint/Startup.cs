using DYHVN3_HFT_2021221.Data;
using DYHVN3_HFT_2021221.Logic;
using DYHVN3_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Swashbuckle.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace DYHVN3_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ILocomotiveLogic, LocomotiveLogic>();
            services.AddTransient<IWagonLogic, WagonLogic>();
            services.AddTransient<IStationLogic, StationLogic>();
            services.AddTransient<ILocomotiveRepository, LocomotiveRepository>();
            services.AddTransient<IWagonRepository, WagonRepository>();
            services.AddTransient<IStationRepository, StationRepository>();
            services.AddTransient<TrainDbContext, TrainDbContext>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DYHVN3_HFT_2021221.Endpoint", Version = "v1" });
            });
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/ swagger / v1 / swagger.json", "DYHVN3_HFT_2021221.Endpoint v1"));

            app.UseEndpoints(endpoints => 
            { 
                endpoints.MapControllers(); 
                endpoints.MapHub<SignalRHub>("/hub"); 
            });
        }
    }
}
