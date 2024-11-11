namespace Finance.Core.Entities
{
    public class ExpenseType : BaseEntity
    {
        public ExpenseType(string name, int idExpenseCategory) : base()
        {
            Name = name;
            IdExpenseCategory = idExpenseCategory;
        }

        public string Name { get; set; } // Energia, Água, Ifood, Festas, Metas etc.
        public int IdExpenseCategory { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }

        public void Update(string name, int idExpenseCategory)
        {
            Name = name;
            IdExpenseCategory = idExpenseCategory;
        }
    }
}
