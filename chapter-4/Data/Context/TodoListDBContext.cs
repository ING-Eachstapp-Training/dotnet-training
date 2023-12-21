using Microsoft.EntityFrameworkCore;

namespace chapter_4.Data.Context
{
    public class TodoListDBContext : DbContext
    {
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:ing-training-sqlserver-dev.database.windows.net,1433;Initial Catalog=ing-training;Persist Security Info=False;User ID=ing-admin;Password=yBTT05FVM70dTGGf;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}

