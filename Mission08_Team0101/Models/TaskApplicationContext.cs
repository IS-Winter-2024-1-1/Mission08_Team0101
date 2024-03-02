using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0101.Models
{
    public class TaskApplicationContext : DbContext
    {
        public TaskApplicationContext(DbContextOptions<TaskApplicationContext> options) : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
