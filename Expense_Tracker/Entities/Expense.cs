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
        public double amount { get; set; }
        public DateOnly date { get; set; }

        // Category as enum
        public CategoryType? category { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
