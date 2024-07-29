using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoItem2.Domain;

namespace ToDoItem2.Infrastructure
{
        public class AppDbContext : DbContext
        {
            public DbSet<ToDoItem> toDoItems { get; set; }
            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=todo;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.HasKey(e => e.taskNum);
                entity.Property(e => e.taskNum)
                      .ValueGeneratedOnAdd(); // Ensure the identity column is auto-generated
            });
            modelBuilder.Entity<ToDoItem>().HasData(
                new ToDoItem { taskNum = 1, taskName = "Task 1" },
                new ToDoItem { taskNum = 2, taskName = "Task 2" },
                new ToDoItem { taskNum = 3, taskName = "Task 3" }
            );
        }
    }
    
}
