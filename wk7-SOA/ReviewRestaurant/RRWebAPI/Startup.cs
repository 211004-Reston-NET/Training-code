using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RRBL;
using RRDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRWebAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RRWebAPI", Version = "v1" });
            });

            //Add your dependencies
            services.AddDbContext<RRDatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Reference2DB")));
            services.AddScoped<IRepository, RespositoryCloud>();
            services.AddScoped<IRestaurantBL, RestaurantBL>();
            services.AddScoped<IReviewBL, ReviewBL>();
            services.AddCors(
                (builder) => {
                    builder.AddDefaultPolicy((policy) => {
                        policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
                            .AllowAnyHeader() //Allows any header we provide in the http header request
                            .AllowAnyMethod(); //Allows any method we provide in the http request
                    });
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RRWebAPI v1"));
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
