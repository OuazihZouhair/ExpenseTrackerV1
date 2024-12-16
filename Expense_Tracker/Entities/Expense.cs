
using Microsoft.AspNetCore.Identity;

namespace Expense_Tracker.Entities
{
    public enum CategoryType
    {
        Food = 1,
        Transport = 2,
        Entertainment = 3
    }


    public class Expense
    {
        public int Id { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
        public DateOnly date { get; set; }

        // Category as enum
        public CategoryType? category { get; set; }

        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}
