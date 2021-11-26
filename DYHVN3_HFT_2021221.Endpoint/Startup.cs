using DYHVN3_HFT_2021221.Data;
using DYHVN3_HFT_2021221.Logic;
using DYHVN3_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
