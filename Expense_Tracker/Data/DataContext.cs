using Expense_Tracker.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Expense relationship
            modelBuilder.Entity<Expense>()
                .HasOne<IdentityUser>()
                .WithMany() // A user can have many expenses
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Budget relationship
            modelBuilder.Entity<Budget>()
                .HasOne<IdentityUser>()
                .WithOne() // A user can have only one budget
                .HasForeignKey<Budget>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Expense category conversion
            modelBuilder.Entity<Expense>()
                .Property(e => e.category)
                .HasConversion<int>(); // Store category as integer in database
        }

    }
}
