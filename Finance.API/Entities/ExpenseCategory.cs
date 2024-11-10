namespace Finance.API.Entities
{
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } // Essencial, Não Essencial, Investimento
        public List<ExpenseType> ExpenseTypes { get; set; }
    }
}
