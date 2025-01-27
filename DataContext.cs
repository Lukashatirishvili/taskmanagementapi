using Microsoft.EntityFrameworkCore;
using taskmanagementapi.Models;

namespace taskmanagementapi
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
