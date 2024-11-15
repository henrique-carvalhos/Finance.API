namespace Finance.Application.Queries.GetExpenseTypeById
{
    public class GetExpenseTypeByIdQuery
    {
        public GetExpenseTypeByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
