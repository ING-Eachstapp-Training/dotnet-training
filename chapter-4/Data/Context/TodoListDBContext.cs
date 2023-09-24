using Microsoft.EntityFrameworkCore;

namespace chapter_4.Data.Context
{
    public class TodoListDBContext : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=ToDoListDB;User=sa;Password=Docker@123;TrustServerCertificate=True;");
        }
    }
}

