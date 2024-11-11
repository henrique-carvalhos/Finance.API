namespace Finance.Core.Entities
{
    public class ExpenseCategory : BaseEntity
    {
        public ExpenseCategory(string name) : base()
        {
            Name = name;

            ExpensesTypes = [];
        }

        public string Name { get; set; } // Essencial, Não Essencial, Investimento
        public List<ExpenseType> ExpensesTypes { get; set; }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
