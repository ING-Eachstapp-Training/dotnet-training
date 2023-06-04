using System;
using chapter_3.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace chapter_3.Database.Context
{
    public class TodoListDBContext : DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TagEntity> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ToDoListDB;User=sa;Password=Docker@123;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagEntity>().HasOne(tag => tag.TaskEntity).WithMany(task => task.TagEntities).HasForeignKey(tag => tag.TaskEntityId);
        }
    }
}

