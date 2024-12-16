using Microsoft.AspNetCore.Identity;

namespace Expense_Tracker.Entities
{
    public class Budget
    {
        public int Id { get; set; }
        public double amount { get; set; }
        public DateOnly createdAt { get; set; }


        // Foreign key to IdentityUser
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}
