using Expense_Tracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expense>()
                .Property(e => e.category)
                .HasConversion<int>(); // Store as integer in database

        }

    }
}
