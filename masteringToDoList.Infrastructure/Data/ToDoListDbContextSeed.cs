using masteringToDoList.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace masteringToDoList.Infrastructure.Data
{
    public class ToDoListDbContextSeed
    {
        public static async Task SeedAsync(ToDoListDbContext ToDoBbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // NOTE : Only run this if using a real database
                // aspnetrunContext.Database.Migrate();
                // aspnetrunContext.Database.EnsureCreated();

                // categories - specifications - reviews - tags
                await SeedToDoListAsync(ToDoBbContext);
                await SeedToDoItemsAsync(ToDoBbContext);
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<ToDoListDbContextSeed>();
                    log.LogError(exception.Message);
                    //await SeedAsync(ToDoBbContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static async Task SeedToDoListAsync(ToDoListDbContext toDoBbContext)
        {
            if (toDoBbContext.ToDoList.Any())
                return;
            var user = toDoBbContext.User.FirstOrDefault();
            if (user != null)
            {
                var toDoList = new List<ToDoList>()
                {
                    new ToDoList() { Name = "First List",User =user,CreatedDate = DateTime.UtcNow,DataStatus = 0},
                    new ToDoList() { Name = "Second List",User =user,CreatedDate = DateTime.UtcNow,DataStatus = 0},
                    new ToDoList() { Name = "Third list",User =user,CreatedDate = DateTime.UtcNow,DataStatus = 0},
                };
                toDoBbContext.ToDoList.AddRange(toDoList);
                await toDoBbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedToDoItemsAsync(ToDoListDbContext toDoBbContext)
        {
            if (toDoBbContext.ToDoItem.Any())
                return;

            var toDoList = toDoBbContext.ToDoList.FirstOrDefault();

            var toDoItems = new List<ToDoItem>()
            {
                new ToDoItem() { Description = "First ToDo Item",ToDoList = toDoList,Status = 0,DeadLine = DateTime.UtcNow.AddDays(30),CreatedDate = DateTime.UtcNow,DataStatus = 0},
                new ToDoItem() { Description = "Second ToDo Item",ToDoList = toDoList,Status = 0,DeadLine = DateTime.UtcNow.AddDays(30),CreatedDate = DateTime.UtcNow,DataStatus = 0},
                new ToDoItem() { Description = "Third ToDo Item",ToDoList = toDoList,Status = 0,DeadLine = DateTime.UtcNow.AddDays(30),CreatedDate = DateTime.UtcNow,DataStatus = 0},
            };

            toDoBbContext.ToDoItem.AddRange(toDoItems);
            await toDoBbContext.SaveChangesAsync();
        }

        public static void InitializeUser(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ToDoListDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "adem@htomail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "adem"
                };
                try
                {
                    var res = userManager.CreateAsync(user, "Adem@123");
                    if (res.Result.Succeeded)
                    {
                        string message = "Success";
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
       
            }
        }
    }
}