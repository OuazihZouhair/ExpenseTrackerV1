namespace Expense_Tracker.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string fName { get; set; } = string.Empty;
        public string lName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public double mBudget { get; set; }
    }
}
