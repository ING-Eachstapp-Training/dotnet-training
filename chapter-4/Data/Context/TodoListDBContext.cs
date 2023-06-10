using System;
using chapter_4.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace chapter_4.Data.Context
{
    public class TodoListDBContext : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ToDoListDBChapter4;User=sa;Password=Docker@123;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasOne(tag => tag.Task).WithMany(task => task.Tags).HasForeignKey(tag => tag.TaskId);
        }
    }
}

