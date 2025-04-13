namespace Some_API.Data.Entities
{
    public class MerchantEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
