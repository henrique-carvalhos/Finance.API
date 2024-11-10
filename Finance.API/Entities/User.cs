namespace Finance.API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
