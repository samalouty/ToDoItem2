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
        }
    
}
