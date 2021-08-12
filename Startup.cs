using GraphDemo.Context;
using GraphDemo.Entities;
using GraphDemo.Services;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphDemo
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly string AllowedOrigin = "allowedOrigin";
        //private readonly GraphLogger logger;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OMSOrdersContext>(options =>
            {
               // options.UseSqlServer(_configuration["Datasources:OMSNETOrders:ConnectionString"]); //This is for MSSQL Database
            });

            services.AddControllersWithViews();
            services.AddApplicationInsightsTelemetry();
            services.AddScoped<IQueryService, QueryService>();

            services
                 .AddGraphQLServer()
                 .AddQueryType<OrderQueries>()
                 .AddType<OrderQueryType>()   
                 .AddFiltering()
                 .AddSorting()
                 .AddProjections();

            services.AddCors(option =>
            {
                option.AddPolicy("allowedOrigin",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    );
            });
            services.AddApplicationInsightsTelemetry(opt => opt.EnableAdaptiveSampling = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
          //  this.logger.BindToILoggerFactory(LoggerFactory);
            if (env.IsDevelopment())
            {
                logger.LogInformation(
                "Configuring for {Environment} environment",
                env.EnvironmentName);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors(AllowedOrigin);

            app
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });
            app.UsePlayground(new PlaygroundOptions
            {
                QueryPath = "/graphql",
                Path = "/playground"
            });
        }
    }
}