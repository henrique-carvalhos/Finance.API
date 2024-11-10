namespace Finance.API.Entities
{
    public class ExpenseType
    {
        public int Id { get; set; }
        public string Name { get; set; } // Energia, Água, Ifood, Festas, Metas etc.
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
    }
}
