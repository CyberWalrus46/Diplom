namespace Core
{
    public class Merchant
    {
        private Merchant(Guid id, string title, string status, string description)
        {
            Id = id;
            Title = title; 
            Status = status;
            Description = description;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Status { get; }
        public string Description { get; } = string.Empty;

        public static (Merchant merchant, string error) Create(Guid id, string title, string status, string description)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(title) || title.Length > 255)
            {
                error = "Title is too small or too long";
            }

            var merchant = new Merchant(id, title, status, description);

            return (merchant, error);
        }
    }
}
