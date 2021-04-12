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
using System;
using System.Reflection;
using Newtonsoft.Json;
using System.Linq;

namespace Chocolate.Eshop
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
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = "Takaros";
            });

            services.AddHttpContextAccessor();

            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<ChocolateDbContext>()
               .AddDefaultTokenProviders();

            services.AddDbContext<ChocolateDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ChocolateConnection"),
                    //enables multiple queries when including entities in Linq
                    //it has better performance overall
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1.1",
                    new OpenApiInfo()
                    {
                        Title = "Chocolate E-shop API",
                        Description = "Chocolate E-shop Swagger",
                        Version = "v1.1"
                    });
                options.CustomSchemaIds(x => x.FullName);
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc().AddNewtonsoftJson(options =>
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseExceptionHandler("/Error");
            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1.1/swagger.json", "Chocolate E-shop API");
            });
        }
    }
}