namespace HelloOrleans.Host.Contract.Entity
{
    public class Thread : BaseEntity
    {
        public string JobId { get; set; }
        public string ContactId { get; set; }
        public EnumThreadStatus Status { get; set; }
    }
}
