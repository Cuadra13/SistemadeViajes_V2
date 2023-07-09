﻿using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace SistemadeViajes_V2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           services.AddControllers();

            services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
           services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(C =>
            {
                C.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemadeViajes", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
