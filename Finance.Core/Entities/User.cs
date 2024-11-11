namespace Finance.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name) 
            : base()
        {
            Name = name;

            Incomes = [];
            Expenses = [];
        }

        public string Name { get; private set; }
        public List<Income> Incomes { get; private set; }
        public List<Expense> Expenses { get; private set; }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
