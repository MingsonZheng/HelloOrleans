namespace HelloOrleans.Host.Contract.Entity
{
    public class Activity : BaseEntity
    {
        public string JobId { get; set; }
        public string ContactId { get; set; }
        public EnumActivityType Type { get; set; }
    }
}
