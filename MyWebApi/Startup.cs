using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using MyWebApi.Model;
using NJsonSchema;
using NSwag.AspNetCore;

namespace MyWebApi
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
            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);
            
            string sConnectionString = Configuration.GetConnectionString("hangfiredb");
            services.AddHangfire(x => x.UseSqlServerStorage(sConnectionString));
            services.AddMvc();
            
            services.AddSingleton<IBackgroundJobClient>(new BackgroundJobClient(
                new SqlServerStorage(sConnectionString)));

            services.AddDbContext<MyWebApiDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MyWebApi")));

            services.AddTransient<IMailListRepository, MailListRepoUsingDB>();
            services.AddTransient<ISendMessage, SendMesageByMail>();
            services.AddTransient<IMyDictionary, MyDictionaryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new CustomAuthorizeFilter() }
            });
            app.UseHangfireServer();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // Enable the Swagger UI middleware and the Swagger generator
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
            });

            app.UseMvc();

            app.Run(context => {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
        }
    }
}
