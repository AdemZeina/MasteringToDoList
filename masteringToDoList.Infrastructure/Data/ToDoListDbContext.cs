using System;
using System.Collections.Generic;
using System.Text;
using masteringToDoList.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace masteringToDoList.Infrastructure.Data
{
    public class ToDoListDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<ApplicationUser> User { get; set; }

        public DbSet<ToDoList> ToDoList { get; set; }

        public DbSet<ToDoItem> ToDoItem { get; set; }

        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options)
        {

        }

        public ToDoListDbContext()
        {
        }

        const string Connection = @"Server=.;Database=ToDoDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        
            base.OnModelCreating(builder);
        }
    }
}
