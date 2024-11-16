namespace Finance.Core.Entities
{
    public class PaymentType : BaseEntity
    {
        public PaymentType(string description) : base()
        {
            Description = description;
        }
        public string Description { get; private set; }

        public void Update(string description)
        {
            Description = description;
        }
    }
}
