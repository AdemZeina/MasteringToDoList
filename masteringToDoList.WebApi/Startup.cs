using masteringToDoList.Core.Entities;
using masteringToDoList.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using AutoMapper;
using masteringToDoList.Application.Interfaces;
using masteringToDoList.Application.Services;
using masteringToDoList.Core.Interfaces;
using masteringToDoList.Core.Repository;
using masteringToDoList.Infrastructure.Logging;
using masteringToDoList.Infrastructure.Repository;
using masteringToDoList.Infrastructure.Repository.Base;
using Swashbuckle.AspNetCore.Swagger;

namespace masteringToDoList.WebApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //add this: simply creates db if it doesn't exist, no migrations
            using (var context = new ToDoListDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureToDoServices(services);
          


            //Add data protection services
            services.AddDataProtection();
    
            services.AddControllers();
           


            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
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
               
                app.UseHsts();
            }


            //app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
       

            //app.UseSwagger();
            //app.UseSwaggerUI(x =>
            //{
            //     x.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Api");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureToDoServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<ToDoListDbContext>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            ConfigureIdentity(services);

            //Add Core And Infrastructure layers
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IToDoListRepository, ToDoListRepository>();

            //// Add Application Layer
            services.AddScoped<IToDoItemsService, ToDoItemsService>();
            services.AddScoped<IToDoListService, ToDoListService>();


            //// Add Web Layer
            services.AddAutoMapper(); // Add AutoMapper
            //services.AddSwaggerGen(c=>c.SwaggerDoc("v1",new Info{Title = "Swagger",Description = ""}));

            // Add Miscellaneous
            services.AddHttpContextAccessor();

          
        }

        public void ConfigureDatabases(IServiceCollection services)
        {
            services.AddDbContext<ToDoListDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ToDoList")));
        }

        public void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ToDoListDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = false;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

         
        }
    }
}