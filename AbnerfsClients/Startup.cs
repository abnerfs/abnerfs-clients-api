using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbnerfsClients.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace AbnerfsClients
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
            var CnSettings = new PostgreConnectionSetting();
            Configuration.GetSection("DbConnection:Default").Bind(CnSettings);

            var cnString = new NpgsqlConnectionStringBuilder
            {
                Database = CnSettings.Database,
                Port = int.Parse(CnSettings.Port),
                SslMode = SslMode.Prefer,
                Host = CnSettings.Host,
                Username = CnSettings.User,
                Password = CnSettings.Password,
                TrustServerCertificate = true
            };

            services.AddControllers();
            services.AddDbContext<PostGresContext>(options =>
            {
                options
                    .UseNpgsql(cnString.ConnectionString);

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
