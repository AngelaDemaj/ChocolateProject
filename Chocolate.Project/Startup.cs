using Autofac;
using AutoMapper;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Reflection;

namespace ChocolateProject
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
            //Here we add Microsoft Identity
            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<ChocolateDbContext>()
               .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            services.AddDbContext<ChocolateDbContext>(options =>
            {
                //we use SQL Server with the chocolateConnection ConnectionString
                options.UseSqlServer(Configuration.GetConnectionString("ChocolateConnection"),
                    //enables multiple queries when including entities in Linq
                    //it has better performance overall
                    //One large query is much slower than many small queries
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

                services.AddRazorPages();
            });

            //Here we declare the swagger options
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "Chocolate Project API",
                        Description = "Chocolate Project Swagger",
                        Version = "v1"
                    });
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.CustomSchemaIds(x => x.FullName);
            });

            //services.AddAutoMapper(Assembly.LoadFrom("Chocolate.DataAccess"));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc()
                //Removes the loops inside JSONs
                 .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 });

            //services.AddScoped<ISupplierService, SupplierService>(); this was replaced by autofac
        }

        //The method that configures autofac dependency injection
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder
               //From the project Chocolate.Business
               .RegisterAssemblyTypes(Assembly.LoadFrom(
                   "../Chocolate.Business/bin/Debug/net5.0/Chocolate.Business.dll"))
               //Get all classes that end with Service
               .Where(t => t.Name.EndsWith("Service"))
               //Resolve their dependencies with their interfaces
               //foreach interface our service implements, we create:
               //services.AddScoped<ITakisService, TakisService>();
               .AsImplementedInterfaces()
               //we create one instance that lives FOREVER!
               .InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/{0}");
                app.UseHsts();
            }

            app.UseExceptionHandler("/Error");
            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Chocolate Project API");
            });
        }
    }
}